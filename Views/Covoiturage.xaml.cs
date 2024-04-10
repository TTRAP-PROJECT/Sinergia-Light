using firstMobileApp.Class;
using firstMobileApp.Models;

namespace firstMobileApp.Views;

public partial class Covoiturage : ContentPage
{
    CovoituragesModel covoituragesModel;
    ToolbarItem soldeToolbarItem;
    public Covoiturage()
	{
		InitializeComponent();
        soldeToolbarItem = new ToolbarItem();
        soldeToolbarItem.Text = UserSessionManager.Solde.ToString() + "💰"; // Remplacez 100 par le solde réel de l'utilisateur
        ToolbarItems.Add(soldeToolbarItem);
        // Créer une instance de votre ViewModel
        covoituragesModel = new CovoituragesModel();

        // Définir le BindingContext sur votre ViewModel
        BindingContext = covoituragesModel;
    }
    protected async override void OnAppearing()
    {
        base.OnAppearing();
        // Appeler la méthode de rafraîchissement des données lorsque la page apparaît
        await covoituragesModel.LoadData();
        await UserSessionManager.UpdateUserData();
        soldeToolbarItem.Text = UserSessionManager.Solde.ToString() + "💰";
    }
    private async void NavigateToCovoiturageDetails(object sender, TappedEventArgs e)
    {
        var tappedLabel = sender as Label;
        var idTrajet = (tappedLabel.BindingContext as Class.Covoiturage).Service.IdService;

        // Appelez votre méthode NavigateToCinemaDetails avec l'ID du film
        if (idTrajet != null)
        {
            await Navigation.PushAsync(new CovoiturageDetail(idTrajet));
        }
    }

    
}