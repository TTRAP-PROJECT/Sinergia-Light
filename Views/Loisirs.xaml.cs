using firstMobileApp.Models;

namespace firstMobileApp.Views;

public partial class Loisirs : ContentPage
{
	public Loisirs()
	{
		InitializeComponent();

        // Cr�er une instance de votre ViewModel
        ViewModel viewModel = new ViewModel();

        // D�finir le BindingContext sur votre ViewModel
        BindingContext = viewModel;
    }
}