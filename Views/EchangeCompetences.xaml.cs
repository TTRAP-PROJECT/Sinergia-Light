using firstMobileApp.Class;
using firstMobileApp.Models;

namespace firstMobileApp.Views;

public partial class EchangeCompetences : ContentPage
{
    EchangesCompetencesModel echangesCompetencesModel;

    public EchangeCompetences()
	{
		InitializeComponent();
        ToolbarItem soldeToolbarItem = new ToolbarItem();
        soldeToolbarItem.Text = UserSessionManager.Solde.ToString() + "💰"; // Remplacez 100 par le solde réel de l'utilisateur
        ToolbarItems.Add(soldeToolbarItem);
        // Créer une instance de votre ViewModel
        EchangesCompetencesModel echangesCompetencesModel = new EchangesCompetencesModel();

        // Définir le BindingContext sur votre ViewModel
        BindingContext = echangesCompetencesModel;
    }

    private async void NavigateToCoursDetails(object sender, TappedEventArgs e)
    {

        var tappedLabel = sender as Label;
        var idCours = (tappedLabel.BindingContext as Class.EchangeCompetences).Service.IdService;
        var test = idCours;

        // Appelez votre méthode NavigateToCinemaDetails avec l'ID du film
        if (idCours != null)
        {
            await Navigation.PushAsync(new EchangeCompetencesDetails(idCours));
        }

    }

    private void RefreshButton_Clicked(object sender, EventArgs e)
    {
        EchangesCompetencesModel echangesCompetencesModel = new EchangesCompetencesModel();

        // Définir le BindingContext sur votre ViewModel
        BindingContext = echangesCompetencesModel;
    }
}