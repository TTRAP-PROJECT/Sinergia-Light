using firstMobileApp.Class;
using firstMobileApp.Models;

namespace firstMobileApp.Views;

public partial class LoisirsDetail : ContentPage
{
    LoisirModel loisirModel;
    ToolbarItem soldeToolbarItem;
    public LoisirsDetail(int idLoisir)
	{
		InitializeComponent();
        InitializeAsync(idLoisir);
        soldeToolbarItem = new ToolbarItem();
        soldeToolbarItem.Text = UserSessionManager.Solde.ToString() + "💰"; // Remplacez 100 par le solde réel de l'utilisateur
        ToolbarItems.Add(soldeToolbarItem);
    }
    protected async override void OnAppearing()
    {
        base.OnAppearing();
        // Appeler la méthode de rafraîchissement des données lorsque la page apparaît
        await loisirModel.LoadData();
        await UserSessionManager.UpdateUserData();
        soldeToolbarItem.Text = UserSessionManager.Solde.ToString() + "💰";
        nb.Text = "Réservations : " + loisirModel.Loisir.NombreDeReservations.ToString() + " / " + loisirModel.Loisir.Service.NbPersonnesMax.ToString();
    }
    private async void InitializeAsync(int idLoisir)
    {
        // Créer une instance de votre ViewModel
        loisirModel = new LoisirModel(idLoisir);

        // Attendre que les données soient chargées
        await loisirModel.LoadData();

        // Définir le BindingContext sur votre ViewModel
        BindingContext = loisirModel;
        description.Text = "Description : " + loisirModel.Loisir.Service.Description;
        nb.Text = "Réservations : " + loisirModel.Loisir.NombreDeReservations.ToString() + " / " + loisirModel.Loisir.Service.NbPersonnesMax.ToString(); 
    }

    private async void ReserverButton_Clicked(object sender, EventArgs e)
    {
        var idLoisir = loisirModel.Loisir.Service.IdService;
        var libelle = loisirModel.Loisir.LibelleLoisir;
        var prix = loisirModel.Loisir.Service.Prix;
        var date = loisirModel.Loisir.Service.DatePrevue;
        var nbReservation = loisirModel.Loisir.NombreDeReservations;
        var nbReservationMax = loisirModel.Loisir.Service.NbPersonnesMax;
        var idVendeur = loisirModel.Loisir.Service.IdVendeur;

        // Appelez votre méthode EstReservable pour vérifier si la réservation est possible
        List<bool> listeBools = await ExceptionModel.EstReservable(idLoisir, (int)prix, date, nbReservationMax, nbReservation, idVendeur);

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
            await Navigation.PushAsync(new Paiment(idLoisir, libelle, (int)prix));
        }
    }
}