using firstMobileApp.Class;
using firstMobileApp.Models;

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
    }

    private async void ReserverButton_Clicked(object sender, EventArgs e)
    {
        var idService = evenementSportifModel.Sport.Service.IdService;
        var libelle = evenementSportifModel.Sport.LibelleSport;
        var prix = evenementSportifModel.Sport.Service.Prix;


        // Appelez votre méthode NavigateToCinemaDetails avec l'ID du film
        if (idService != null)
        {
            await Navigation.PushAsync(new Paiment(idService, libelle, (int)prix));
        }
    }
}