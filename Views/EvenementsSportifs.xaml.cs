using firstMobileApp.Class;
using firstMobileApp.Models;

namespace firstMobileApp.Views;

public partial class EvenementsSportifs : ContentPage
{
    EvenementsSportifsModel evenementsSportifs;
    ToolbarItem soldeToolbarItem;
    public EvenementsSportifs()
	{
		InitializeComponent();
        soldeToolbarItem = new ToolbarItem();
        soldeToolbarItem.Text = UserSessionManager.Solde.ToString() + "💰"; // Remplacez 100 par le solde réel de l'utilisateur
        ToolbarItems.Add(soldeToolbarItem);
        // Créer une instance de votre ViewModel
        evenementsSportifs = new EvenementsSportifsModel();

        // Définir le BindingContext sur votre ViewModel
        BindingContext = evenementsSportifs;
    }
    protected async override void OnAppearing()
    {
        base.OnAppearing();
        // Appeler la méthode de rafraîchissement des données lorsque la page apparaît
        await evenementsSportifs.LoadData();
        await UserSessionManager.UpdateUserData();
        soldeToolbarItem.Text = UserSessionManager.Solde.ToString() + "💰";
    }
    private async void NavigateToSportDetails(object sender, TappedEventArgs e)
    {

        var tappedLabel = sender as Label;
        var idSport = (tappedLabel.BindingContext as Class.EvenementsSportifs).Service.IdService;
        var test = idSport;

        // Appelez votre méthode NavigateToCinemaDetails avec l'ID du film
        if (idSport != null)
        {
            await Navigation.PushAsync(new EvenementSportifsDetails(idSport));
        }

    }

    
}