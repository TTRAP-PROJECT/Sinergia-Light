using firstMobileApp.Models;

namespace firstMobileApp.Views;

public partial class talkPage : ContentPage
{
	public talkPage()
	{
		InitializeComponent();

        // Cr�er une instance de votre ViewModel
        EvenementsSportifsModel evenementsSportifs = new EvenementsSportifsModel();

        // D�finir le BindingContext sur votre ViewModel
        BindingContext = evenementsSportifs;

    }

}