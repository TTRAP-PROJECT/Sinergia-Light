using firstMobileApp.Class;
using firstMobileApp.Models;

namespace firstMobileApp.Views;

public partial class Loisirs : ContentPage
{
    LoisirsModel loisirsModel;

    public Loisirs()
	{
		InitializeComponent();
        ToolbarItem soldeToolbarItem = new ToolbarItem();
        soldeToolbarItem.Text = UserSessionManager.Solde.ToString() + "💰"; // Remplacez 100 par le solde réel de l'utilisateur
        ToolbarItems.Add(soldeToolbarItem);
        // Créer une instance de votre ViewModel
        loisirsModel = new LoisirsModel();

        // Définir le BindingContext sur votre ViewModel
        BindingContext = loisirsModel;
    }

    private async void NavigateToLoisirsDetails(object sender, TappedEventArgs e)
    {
        var tappedLabel = sender as Label;
        var idLoisir = (tappedLabel.BindingContext as Class.Loisirs).Service.IdService;

        // Appelez votre méthode NavigateToCinemaDetails avec l'ID du film
        if (idLoisir != null)
        {
            await Navigation.PushAsync(new LoisirsDetail(idLoisir));
        }
    }

    private void RefreshButton_Clicked(object sender, EventArgs e)
    {
        loisirsModel = new LoisirsModel();

        // Définir le BindingContext sur votre ViewModel
        BindingContext = loisirsModel;
    }
}