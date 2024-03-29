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
}