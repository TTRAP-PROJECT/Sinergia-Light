using Microsoft.Maui.Controls;
using firstMobileApp.Class;  // Assurez-vous d'importer votre classe ViewModel

namespace firstMobileApp.Views
{
    public partial class searchPage : ContentPage
    {
        public searchPage()
        {
            InitializeComponent();

            // Créer une instance de votre ViewModel
            ViewModel viewModel = new ViewModel();

            // Définir le BindingContext sur votre ViewModel
            BindingContext = viewModel;
        }
    }
}