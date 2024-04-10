using firstMobileApp.Class;
using firstMobileApp.Models;

namespace firstMobileApp.Views;

public partial class EchangeCompetences : ContentPage
{
    EchangesCompetencesModel echangesCompetencesModel;
    ToolbarItem soldeToolbarItem;

    public EchangeCompetences()
    {
        InitializeComponent();

        soldeToolbarItem = new ToolbarItem();
        soldeToolbarItem.Text = UserSessionManager.Solde.ToString() + "💰";
        ToolbarItems.Add(soldeToolbarItem);

        // Créez une instance de votre ViewModel et assignez-la à la variable de classe
        echangesCompetencesModel = new EchangesCompetencesModel();

        // Définir le BindingContext sur votre ViewModel
        BindingContext = echangesCompetencesModel;
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        // Appeler la méthode de rafraîchissement des données lorsque la page apparaît
        await echangesCompetencesModel.LoadData();
        await UserSessionManager.UpdateUserData();
        soldeToolbarItem.Text = UserSessionManager.Solde.ToString() + "💰";
    }

    private async void NavigateToCoursDetails(object sender, TappedEventArgs e)
    {
        var tappedLabel = sender as Label;
        var idCours = (tappedLabel.BindingContext as Class.EchangeCompetences).Service.IdService;

        // Appelez votre méthode NavigateToCinemaDetails avec l'ID du cours
        if (idCours != null)
        {
            await Navigation.PushAsync(new EchangeCompetencesDetails(idCours));
        }
    }
}