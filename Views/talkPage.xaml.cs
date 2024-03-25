using firstMobileApp.Models;

namespace firstMobileApp.Views;

public partial class talkPage : ContentPage
{
	public talkPage()
	{
		InitializeComponent();

        // Créer une instance de votre ViewModel
        EvenementsSportifsModel evenementsSportifs = new EvenementsSportifsModel();

        // Définir le BindingContext sur votre ViewModel
        BindingContext = evenementsSportifs;

    }

}