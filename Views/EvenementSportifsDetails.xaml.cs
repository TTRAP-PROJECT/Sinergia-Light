using firstMobileApp.Class;
using firstMobileApp.Models;
using System.IO;

namespace firstMobileApp.Views;

public partial class EvenementSportifsDetails : ContentPage
{
    EvenementSportifModel evenementSportifModel;
    public EvenementSportifsDetails(int idSport)
    {
        InitializeComponent();
        InitializeAsync(idSport);
        ToolbarItem soldeToolbarItem = new ToolbarItem();
        soldeToolbarItem.Text = UserSessionManager.Solde.ToString() + "💰"; // Remplacez 100 par le solde réel de l'utilisateur
        ToolbarItems.Add(soldeToolbarItem);
    }

    private async void InitializeAsync(int idSport)
    {
        // Créer une instance de votre ViewModel
        evenementSportifModel = new EvenementSportifModel(idSport);

        // Attendre que les données soient chargées
        await evenementSportifModel.LoadData();

        // Définir le BindingContext sur votre ViewModel
        BindingContext = evenementSportifModel;
        description.Text = "Description : " + evenementSportifModel.Sport.Service.Description;
        nb.Text = "Réservations : " + evenementSportifModel.Sport.NombreDeReservations.ToString() + " / " + evenementSportifModel.Sport.Service.NbPersonnesMax.ToString();

    }

    private async void ReserverButton_Clicked(object sender, EventArgs e)
    {
        var idSport = evenementSportifModel.Sport.Service.IdService;
        var libelle = evenementSportifModel.Sport.LibelleSport;
        var prix = evenementSportifModel.Sport.Service.Prix;
        var date = evenementSportifModel.Sport.Service.DatePrevue;
        var nbReservation = evenementSportifModel.Sport.NombreDeReservations;
        var nbReservationMax = evenementSportifModel.Sport.Service.NbPersonnesMax;

        // Appelez votre méthode EstReservable pour vérifier si la réservation est possible
        List<bool> listeBools = await ExceptionModel.EstReservable(idSport, (int)prix, date, nbReservationMax, nbReservation);

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
            await Navigation.PushAsync(new Paiment(idSport, libelle, (int)prix));
        }
    }
}