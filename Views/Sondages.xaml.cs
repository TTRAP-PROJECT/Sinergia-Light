using firstMobileApp.Models;

namespace firstMobileApp.Views;

public partial class Sondages : ContentPage
{
    SondagesModel sondagesModel;
    VoteModel voteModel;

    public Sondages()
	{
		InitializeComponent();

        // Créer une instance de votre ViewModel
        sondagesModel = new SondagesModel();
        voteModel = new VoteModel();

        // Définir le BindingContext sur votre ViewModel
        BindingContext = sondagesModel;
    }

    private async void PourButton_Clicked(object sender, EventArgs e)
    {
        var tappedLabel = sender as Button;
        var idSondage = (tappedLabel.BindingContext as Class.Sondages).IdSondage;
        string result = await voteModel.VoterPour(idSondage);
        if(result == "\"Votre vote a été pris en compte\"") 
        {
            await DisplayAlert("Vote réussi", "Votre vote a été pris en compte", "OK");
        }
        if (result == "\"Vous avez déja voté pour ce sondage\"")
        {

            await DisplayAlert("Vote échoué", "Vous avez déja voté pour ce sondage", "OK");
        }
    }

    private async void ContreButton_Clicked(object sender, EventArgs e)
    {
        var tappedLabel = sender as Button;
        var idSondage = (tappedLabel.BindingContext as Class.Sondages).IdSondage;
        string result = await voteModel.VoterContre(idSondage);
        if (result == "\"Votre vote a été pris en compte\"")
        {
            await DisplayAlert("Vote réussi", "Votre vote a été pris en compte", "OK");
        }
        if (result == "\"Vous avez déja voté pour ce sondage\"")
        {

            await DisplayAlert("Vote échoué", "Vous avez déja voté pour ce sondage", "OK");
        }
    }
}