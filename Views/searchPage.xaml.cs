using Microsoft.Maui.Controls;
using firstMobileApp.Models;  // Assurez-vous d'importer votre classe ViewModel

namespace firstMobileApp.Views
{
    public partial class searchPage : ContentPage
    {
        public searchPage()
        {
            InitializeComponent();
        }
        private async void NavigateToEvenementsSportifs(object sender, EventArgs e)
        {
            // Navigate to the desired page
            await Navigation.PushAsync(new EvenementsSportifs());
        }
        private async void NavigateToEchangeCompetences(object sender, EventArgs e)
        {
            // Navigate to the desired page
            await Navigation.PushAsync(new EchangeCompetences());
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
}