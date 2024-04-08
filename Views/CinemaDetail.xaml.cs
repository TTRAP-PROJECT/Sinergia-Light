using firstMobileApp.Class;
using firstMobileApp.Models;

namespace firstMobileApp.Views
{
    public partial class CinemaDetail : ContentPage
    {
        FilmModel filmModel;
        public CinemaDetail(int idFilm)
        {
            InitializeComponent();
            InitializeAsync(idFilm);
            ToolbarItem soldeToolbarItem = new ToolbarItem();
            soldeToolbarItem.Text = UserSessionManager.Solde.ToString() + "💰"; // Remplacez 100 par le solde réel de l'utilisateur
            ToolbarItems.Add(soldeToolbarItem);
        }

        private async void InitializeAsync(int idFilm)
        {
            // Créer une instance de votre ViewModel
            filmModel = new FilmModel(idFilm);

            // Attendre que les données soient chargées
            await filmModel.LoadData();

            // Définir le BindingContext sur votre ViewModel
            BindingContext = filmModel;
            description.Text = "Description : " + filmModel.Film.Service.Description;
        }

        private async void ReserverButton_Clicked(object sender, EventArgs e)
        {
            var idService = filmModel.Film.Service.IdService;
            var libelle = filmModel.Film.Service.LibelleService;
            var prix = filmModel.Film.Service.Prix;


            // Appelez votre méthode NavigateToCinemaDetails avec l'ID du film
            if (idService != null)
            {
                await Navigation.PushAsync(new Paiment(idService, libelle, (int)prix));
            }
        }
    }
}
