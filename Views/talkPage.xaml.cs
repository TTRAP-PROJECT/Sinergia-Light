using firstMobileApp.Class;

namespace firstMobileApp.Views;

public partial class talkPage : ContentPage
{
	public talkPage()
	{
		InitializeComponent();

        // Cr�er une instance de votre ViewModel
        UsersModel usersModel = new UsersModel();

        // D�finir le BindingContext sur votre ViewModel
        BindingContext = usersModel;

    }

}