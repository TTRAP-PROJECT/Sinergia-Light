using firstMobileApp.Models;

namespace firstMobileApp.Views;

public partial class Loisirs : ContentPage
{
	public Loisirs()
	{
		InitializeComponent();

        // Créer une instance de votre ViewModel
        LoisirsModel loisirsModel = new LoisirsModel();

        // Définir le BindingContext sur votre ViewModel
        BindingContext = loisirsModel;
    }

    private void NavigateToLoisirsDetails(object sender, TappedEventArgs e)
    {

    }
}