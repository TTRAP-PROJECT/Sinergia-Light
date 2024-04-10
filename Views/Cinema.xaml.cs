using firstMobileApp.Class;
using firstMobileApp.Models;

namespace firstMobileApp.Views;

public partial class Cinema : ContentPage
{
    CinemaModel cinemaModel;
    ToolbarItem soldeToolbarItem;
    public Cinema()
	{
		InitializeComponent();
        soldeToolbarItem = new ToolbarItem();
        soldeToolbarItem.Text = UserSessionManager.Solde.ToString() + "💰"; // Remplacez 100 par le solde réel de l'utilisateur
        ToolbarItems.Add(soldeToolbarItem);

        // Créer une instance de votre ViewModel
        cinemaModel = new CinemaModel();

        // Définir le BindingContext sur votre ViewModel
        BindingContext = cinemaModel;
    }
    protected async override void OnAppearing()
    {
        base.OnAppearing();
        // Appeler la méthode de rafraîchissement des données lorsque la page apparaît
        await cinemaModel.LoadData();
        await UserSessionManager.UpdateUserData();
        soldeToolbarItem.Text = UserSessionManager.Solde.ToString() + "💰";
    }

    private async void NavigateToCinemaDetails(object sender, TappedEventArgs e)
    {

        var tappedLabel = sender as Label;
        var idFilm = (tappedLabel.BindingContext as Class.Cinema).Service.IdService;

        // Appelez votre méthode NavigateToCinemaDetails avec l'ID du film
        if (idFilm != null)
        {
            await Navigation.PushAsync(new CinemaDetail(idFilm));
        }
        
    }

    
}