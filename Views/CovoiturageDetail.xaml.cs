using firstMobileApp.Class;
using firstMobileApp.Models;

namespace firstMobileApp.Views;

public partial class CovoiturageDetail : ContentPage
{
    CovoiturageModel covoiturageModel;
    ToolbarItem soldeToolbarItem;
    public CovoiturageDetail(int idTrajet)
    {
        InitializeComponent();
        InitializeAsync(idTrajet);
        soldeToolbarItem = new ToolbarItem();
        soldeToolbarItem.Text = UserSessionManager.Solde.ToString() + "💰"; // Remplacez 100 par le solde réel de l'utilisateur
        ToolbarItems.Add(soldeToolbarItem);
    }
    protected async override void OnAppearing()
    {
        base.OnAppearing();
        // Appeler la méthode de rafraîchissement des données lorsque la page apparaît
        await covoiturageModel.LoadData();
        await UserSessionManager.UpdateUserData();
        soldeToolbarItem.Text = UserSessionManager.Solde.ToString() + "💰";
        nb.Text = "Réservations : " + covoiturageModel.Trajet.NombreDeReservations.ToString() + " / " + covoiturageModel.Trajet.Service.NbPersonnesMax.ToString();
    }
    private async void InitializeAsync(int idTrajet)
    {
        // Créer une instance de votre ViewModel
        covoiturageModel = new CovoiturageModel(idTrajet);

        // Attendre que les données soient chargées
        await covoiturageModel.LoadData();

        // Définir le BindingContext sur votre ViewModel
        BindingContext = covoiturageModel;
        description.Text = "Description : " + covoiturageModel.Trajet.Service.Description;
        trajet.Text = covoiturageModel.Trajet.LieuDepart + " ⮕ " + covoiturageModel.Trajet.LieuArrivee;
        nb.Text = "Réservations : " + covoiturageModel.Trajet.NombreDeReservations.ToString() + " / " + covoiturageModel.Trajet.Service.NbPersonnesMax.ToString();
    }

    private async void ReserverButton_Clicked(object sender, EventArgs e)
    {
        var idTrajet = covoiturageModel.Trajet.Service.IdService;
        var libelle = trajet.Text;
        var prix = covoiturageModel.Trajet.Service.Prix;
        var date = covoiturageModel.Trajet.Service.DatePrevue;
        var nbReservation = covoiturageModel.Trajet.NombreDeReservations;
        var nbReservationMax = covoiturageModel.Trajet.Service.NbPersonnesMax;
        var idVendeur = covoiturageModel.Trajet.Service.IdVendeur;

        // Appelez votre méthode EstReservable pour vérifier si la réservation est possible
        List<bool> listeBools = await ExceptionModel.EstReservable(idTrajet, (int)prix, date, nbReservationMax, nbReservation, idVendeur);

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
        if (listeBools[4])
        {
            erreurs.Add("Vous êtes le propriétaire de ce service.");
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
            await Navigation.PushAsync(new Paiment(idTrajet, libelle, (int)prix));
        }
    }
}
