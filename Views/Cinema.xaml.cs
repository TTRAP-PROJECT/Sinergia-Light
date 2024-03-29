using firstMobileApp.Models;

namespace firstMobileApp.Views;

public partial class Cinema : ContentPage
{
	public Cinema()
	{
		InitializeComponent();

        // Créer une instance de votre ViewModel
        CinemaModel cinemaModel = new CinemaModel();

        // Définir le BindingContext sur votre ViewModel
        BindingContext = cinemaModel;
    }
}