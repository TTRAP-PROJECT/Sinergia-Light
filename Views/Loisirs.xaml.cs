using firstMobileApp.Models;

namespace firstMobileApp.Views;

public partial class Loisirs : ContentPage
{
	public Loisirs()
	{
		InitializeComponent();

        // Créer une instance de votre ViewModel
        ViewModel viewModel = new ViewModel();

        // Définir le BindingContext sur votre ViewModel
        BindingContext = viewModel;
    }
}