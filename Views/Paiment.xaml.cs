using firstMobileApp.Class;
using firstMobileApp.Models;

namespace firstMobileApp.Views;

public partial class Paiment : ContentPage
{
    int idService;
    int prix;
    public Paiment(int idService, string libelle, int prix)
    {
        InitializeComponent();
        UserSessionManager.UpdateUserData();
        ToolbarItem soldeToolbarItem = new ToolbarItem();
        soldeToolbarItem.Text = UserSessionManager.Solde.ToString() + "💰"; // Remplacez 100 par le solde réel de l'utilisateur
        ToolbarItems.Add(soldeToolbarItem);
        this.idService = idService;
        this.prix = prix;
        libelleService.Text = libelle;
        prixService.Text = "Prix : " + prix.ToString() + "💰";
        solde.Text = "Solde : " + UserSessionManager.Solde.ToString() + "💰";
        total.Text = "Total : " + (UserSessionManager.Solde - prix).ToString() + "💰";
    }

    

    private async void PaymentButton_Clicked(object sender, EventArgs e)
    {
        PaymentModel P = new PaymentModel(idService);
        await P.PostData();
        if (P.aFonctionne)
        {
            await DisplayAlert("Réservation réussie", "Le service a été réservé avec succès.", "OK");
            await Navigation.PopAsync();
        }
    }
}