using firstMobileApp.Class;
using firstMobileApp.Models;

namespace firstMobileApp.Views;

public partial class Covoiturage : ContentPage
{
    CovoituragesModel covoituragesModel;

    public Covoiturage()
	{
		InitializeComponent();
        ToolbarItem soldeToolbarItem = new ToolbarItem();
        soldeToolbarItem.Text = UserSessionManager.Solde.ToString() + "💰"; // Remplacez 100 par le solde réel de l'utilisateur
        ToolbarItems.Add(soldeToolbarItem);
        // Créer une instance de votre ViewModel
        covoituragesModel = new CovoituragesModel();

        // Définir le BindingContext sur votre ViewModel
        BindingContext = covoituragesModel;
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

    private void RefreshButton_Clicked(object sender, EventArgs e)
    {
        // Créer une instance de votre ViewModel
        covoituragesModel = new CovoituragesModel();

        // Définir le BindingContext sur votre ViewModel
        BindingContext = covoituragesModel;
    }
}