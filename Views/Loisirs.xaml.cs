using firstMobileApp.Models;

namespace firstMobileApp.Views;

public partial class Loisirs : ContentPage
{
	public Loisirs()
	{
		InitializeComponent();

        // Cr�er une instance de votre ViewModel
        LoisirsModel loisirsModel = new LoisirsModel();

        // D�finir le BindingContext sur votre ViewModel
        BindingContext = loisirsModel;
    }

    private void NavigateToLoisirsDetails(object sender, TappedEventArgs e)
    {

    }
}