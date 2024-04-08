using firstMobileApp.Models;

namespace firstMobileApp.Views
{
    public partial class CinemaDetail : ContentPage
    {
        public CinemaDetail(int idFilm)
        {
            InitializeComponent();
            InitializeAsync(idFilm);
        }

        private async void InitializeAsync(int idFilm)
        {
            // Cr�er une instance de votre ViewModel
            FilmModel filmModel = new FilmModel(idFilm);

            // Attendre que les donn�es soient charg�es
            await filmModel.LoadData();

            // D�finir le BindingContext sur votre ViewModel
            BindingContext = filmModel;
            description.Text = "Description : " + filmModel.Film.Service.Description;
        }

        private void ReserverButton_Clicked(object sender, EventArgs e)
        {
        }
    }
}
