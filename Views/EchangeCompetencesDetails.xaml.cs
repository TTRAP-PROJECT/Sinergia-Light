using firstMobileApp.Class;
using firstMobileApp.Models;

namespace firstMobileApp.Views;

public partial class EchangeCompetencesDetails : ContentPage
{
    EchangeCompetencesModel echangeCompetences;

    public EchangeCompetencesDetails(int idCours)
	{
		InitializeComponent();
        InitializeAsync(idCours);
        ToolbarItem soldeToolbarItem = new ToolbarItem();
        soldeToolbarItem.Text = UserSessionManager.Solde.ToString() + "💰"; // Remplacez 100 par le solde réel de l'utilisateur
        ToolbarItems.Add(soldeToolbarItem);
    }

    private async void InitializeAsync(int idCours)
    {
        // Créer une instance de votre ViewModel
        echangeCompetences = new EchangeCompetencesModel(idCours);

        // Attendre que les données soient chargées
        await echangeCompetences.LoadData();

        // Définir le BindingContext sur votre ViewModel
        BindingContext = echangeCompetences;
        description.Text = "Description : " + echangeCompetences.Cours.Service.Description;
        nb.Text = "Réservations : " + echangeCompetences.Cours.NombreDeReservations.ToString() + " / " + echangeCompetences.Cours.Service.NbPersonnesMax.ToString();
    }

    private async void ReserverButton_Clicked(object sender, EventArgs e)
    {
        var idCours = echangeCompetences.Cours.Service.IdService;
        var libelle = echangeCompetences.Cours.Matiere;
        var prix = echangeCompetences.Cours.Service.Prix;
        var date = echangeCompetences.Cours.Service.DatePrevue;
        var nbReservation = echangeCompetences.Cours.NombreDeReservations;
        var nbReservationMax = echangeCompetences.Cours.Service.NbPersonnesMax;

        // Appelez votre méthode EstReservable pour vérifier si la réservation est possible
        List<bool> listeBools = await ExceptionModel.EstReservable(idCours, (int)prix, date, nbReservationMax, nbReservation);

        // Liste pour stocker les messages d'erreur
        List<string> erreurs = new List<string>();

        // Vérifier chaque booléen renvoyé par EstReservable
        if (listeBools[0])
        {
            erreurs.Add("Date dépassée.");
        }
        if (listeBools[1])
        {
            erreurs.Add("Service déjà réservé.");
        }
        if (listeBools[2])
        {
            erreurs.Add("Plus de place disponible.");
        }
        if (listeBools[3])
        {
            erreurs.Add("Solde insuffisant.");
        }

        // Afficher une alerte si des erreurs ont été trouvées, sinon procéder au paiement
        if (erreurs.Count > 0)
        {
            string messageErreur = "";
            foreach (string err in erreurs)
            {
                messageErreur += "- " + err + "\n";
            }
            await DisplayAlert("Impossible de réserver :", messageErreur, "OK");
        }
        else
        {
            // Aucune erreur, procéder au paiement
            await Navigation.PushAsync(new Paiment(idCours, libelle, (int)prix));
        }
    }
}