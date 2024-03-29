using firstMobileApp.Models;

namespace firstMobileApp.Views;

public partial class addPage : ContentPage
{
	public addPage()
	{
		InitializeComponent();

        // Cr�er une instance de votre ViewModel
        ViewModel viewModel = new ViewModel();

        // D�finir le BindingContext sur votre ViewModel
        BindingContext = viewModel;
    }

    private async void NavigateToEvenementsSportifs(object sender, EventArgs e)
    {
        // Navigate to the desired page
        await Navigation.PushAsync(new EvenementsSportifs());
    }
    private async void NavigateToEchangeConnaissances(object sender, EventArgs e)
    {
        // Navigate to the desired page
        await Navigation.PushAsync(new EchangeConnaissances());
    }
    private async void NavigateToCinema(object sender, EventArgs e)
    {
        // Navigate to the desired page
        await Navigation.PushAsync(new Cinema());
    }
    private async void NavigateToCovoiturage(object sender, EventArgs e)
    {
        // Navigate to the desired page
        await Navigation.PushAsync(new Covoiturage());
    }
    private async void NavigateToLoisirs(object sender, EventArgs e)
    {
        // Navigate to the desired page
        await Navigation.PushAsync(new Loisirs());
    }
    private async void NavigateToSondages(object sender, EventArgs e)
    {
        // Navigate to the desired page
        await Navigation.PushAsync(new Sondages());
    }
}