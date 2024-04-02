using firstMobileApp.Models;

namespace firstMobileApp.Views;

public partial class Cinema : ContentPage
{
	public Cinema()
	{
		InitializeComponent();

        // Cr�er une instance de votre ViewModel
        CinemaModel cinemaModel = new CinemaModel();

        // D�finir le BindingContext sur votre ViewModel
        BindingContext = cinemaModel;
    }

    private async void NavigateToCinemaDetails(object sender, TappedEventArgs e)
    {

        var tappedLabel = sender as Label;
        var idFilm = (tappedLabel.BindingContext as Class.Cinema).Service.IdService;

        // Appelez votre m�thode NavigateToCinemaDetails avec l'ID du film
        if (idFilm != null)
        {
            await Navigation.PushAsync(new CinemaDetail(idFilm));
        }
        
    }
}