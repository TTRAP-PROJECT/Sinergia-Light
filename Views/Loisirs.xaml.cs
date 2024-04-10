using firstMobileApp.Class;
using firstMobileApp.Models;

namespace firstMobileApp.Views;

public partial class Loisirs : ContentPage
{
    LoisirsModel loisirsModel;
    ToolbarItem soldeToolbarItem;

    public Loisirs()
	{
		InitializeComponent();
        soldeToolbarItem = new ToolbarItem();
        soldeToolbarItem.Text = UserSessionManager.Solde.ToString() + "💰"; // Remplacez 100 par le solde réel de l'utilisateur
        ToolbarItems.Add(soldeToolbarItem);
        // Créer une instance de votre ViewModel
        loisirsModel = new LoisirsModel();

        // Définir le BindingContext sur votre ViewModel
        BindingContext = loisirsModel;
    }
    protected async override void OnAppearing()
    {
        base.OnAppearing();
        // Appeler la méthode de rafraîchissement des données lorsque la page apparaît
        await loisirsModel.LoadData();
        await UserSessionManager.UpdateUserData();
        soldeToolbarItem.Text = UserSessionManager.Solde.ToString() + "💰";
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

    private async void RefreshButton_Clicked(object sender, EventArgs e)
    {
        loisirsModel.LoadData();
        await UserSessionManager.UpdateUserData();
        soldeToolbarItem.Text = UserSessionManager.Solde.ToString() + "💰";
    }
}