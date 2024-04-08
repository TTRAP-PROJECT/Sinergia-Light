using firstMobileApp.Models;

namespace firstMobileApp.Views;

public partial class EvenementsSportifs : ContentPage
{
	public EvenementsSportifs()
	{
		InitializeComponent();

        // Créer une instance de votre ViewModel
        EvenementsSportifsModel evenementsSportifs = new EvenementsSportifsModel();

        // Définir le BindingContext sur votre ViewModel
        BindingContext = evenementsSportifs;
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