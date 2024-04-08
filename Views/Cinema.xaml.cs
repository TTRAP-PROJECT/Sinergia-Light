﻿using firstMobileApp.Class;
using firstMobileApp.Models;

namespace firstMobileApp.Views;

public partial class Cinema : ContentPage
{
	public Cinema()
	{
		InitializeComponent();
        ToolbarItem soldeToolbarItem = new ToolbarItem();
        soldeToolbarItem.Text = UserSessionManager.Solde.ToString() + "💰"; // Remplacez 100 par le solde réel de l'utilisateur
        ToolbarItems.Add(soldeToolbarItem);

        // Créer une instance de votre ViewModel
        CinemaModel cinemaModel = new CinemaModel();

        // Définir le BindingContext sur votre ViewModel
        BindingContext = cinemaModel;
    }

    private async void NavigateToCinemaDetails(object sender, TappedEventArgs e)
    {

        var tappedLabel = sender as Label;
        var idFilm = (tappedLabel.BindingContext as Class.Cinema).Service.IdService;

        // Appelez votre méthode NavigateToCinemaDetails avec l'ID du film
        if (idFilm != null)
        {
            await Navigation.PushAsync(new CinemaDetail(idFilm));
        }
        
    }
}