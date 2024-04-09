using firstMobileApp.Models;

namespace firstMobileApp.Views;

public partial class Sondages : ContentPage
{
    SondagesModel sondagesModel;
    VoteModel voteModel;

    public Sondages()
	{
		InitializeComponent();

        // Cr�er une instance de votre ViewModel
        sondagesModel = new SondagesModel();
        voteModel = new VoteModel();

        // D�finir le BindingContext sur votre ViewModel
        BindingContext = sondagesModel;
    }

    private async void PourButton_Clicked(object sender, EventArgs e)
    {
        var tappedLabel = sender as Button;
        var idSondage = (tappedLabel.BindingContext as Class.Sondages).IdSondage;
        string result = await voteModel.VoterPour(idSondage);
        if(result == "\"Votre vote a �t� pris en compte\"") 
        {
            await DisplayAlert("Vote r�ussi", "Votre vote a �t� pris en compte", "OK");
        }
        if (result == "\"Vous avez d�ja vot� pour ce sondage\"")
        {

            await DisplayAlert("Vote �chou�", "Vous avez d�ja vot� pour ce sondage", "OK");
        }
    }

    private async void ContreButton_Clicked(object sender, EventArgs e)
    {
        var tappedLabel = sender as Button;
        var idSondage = (tappedLabel.BindingContext as Class.Sondages).IdSondage;
        string result = await voteModel.VoterContre(idSondage);
        if (result == "\"Votre vote a �t� pris en compte\"")
        {
            await DisplayAlert("Vote r�ussi", "Votre vote a �t� pris en compte", "OK");
        }
        if (result == "\"Vous avez d�ja vot� pour ce sondage\"")
        {

            await DisplayAlert("Vote �chou�", "Vous avez d�ja vot� pour ce sondage", "OK");
        }
    }
}