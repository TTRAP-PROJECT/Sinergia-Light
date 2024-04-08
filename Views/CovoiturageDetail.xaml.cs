using firstMobileApp.Class;
using firstMobileApp.Models;

namespace firstMobileApp.Views;

public partial class CovoiturageDetail : ContentPage
{
    CovoiturageModel covoiturageModel;
    public CovoiturageDetail(int idTrajet)
    {
        InitializeComponent();
        InitializeAsync(idTrajet);
        ToolbarItem soldeToolbarItem = new ToolbarItem();
        soldeToolbarItem.Text = UserSessionManager.Solde.ToString() + "💰"; // Remplacez 100 par le solde réel de l'utilisateur
        ToolbarItems.Add(soldeToolbarItem);
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
        trajet.Text = covoiturageModel.Trajet.LieuDepart + " → " + covoiturageModel.Trajet.LieuArrivee;
    }

    private async void ReserverButton_Clicked(object sender, EventArgs e)
    {
        var idService = covoiturageModel.Trajet.Service.IdService;
        var libelle = trajet.Text;
        var prix = covoiturageModel.Trajet.Service.Prix;


        // Appelez votre méthode NavigateToCinemaDetails avec l'ID du film
        if (idService != null)
        {
            await Navigation.PushAsync(new Paiment(idService, libelle, (int)prix));
        }
    }
}
