using firstMobileApp.Models;

namespace firstMobileApp.Views;

public partial class EchangeConnaissances : ContentPage
{
	public EchangeConnaissances()
	{
		InitializeComponent();

        // Cr�er une instance de votre ViewModel
        ViewModel viewModel = new ViewModel();

        // D�finir le BindingContext sur votre ViewModel
        BindingContext = viewModel;
    }
}