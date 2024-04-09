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
            nb.Text = "Réservations : " + filmModel.Film.NombreDeReservations.ToString() + " / " + filmModel.Film.Service.NbPersonnesMax.ToString();
        }

        private async void ReserverButton_Clicked(object sender, EventArgs e)
        {
            var idFilm = filmModel.Film.Service.IdService;
            var libelle = filmModel.Film.NomFilm;
            var prix = filmModel.Film.Service.Prix;
            var date = filmModel.Film.Service.DatePrevue;
            var nbReservation = filmModel.Film.NombreDeReservations;
            var nbReservationMax = filmModel.Film.Service.NbPersonnesMax;

            // Appelez votre méthode EstReservable pour vérifier si la réservation est possible
            List<bool> listeBools = await ExceptionModel.EstReservable(idFilm, (int)prix, date, nbReservationMax, nbReservation);

            // Liste pour stocker les messages d'erreur
            List<string> erreurs = new List<string>();

            // Vérifier chaque booléen renvoyé par EstReservable
            if (listeBools[0])
            {
                erreurs.Add("Date dépassée.");
            }
            if (listeBools[1])
            {
                erreurs.Add("Service déjà réservé.");
            }
            if (listeBools[2])
            {
                erreurs.Add("Plus de place disponible.");
            }
            if (listeBools[3])
            {
                erreurs.Add("Solde insuffisant.");
            }

            // Afficher une alerte si des erreurs ont été trouvées, sinon procéder au paiement
            if (erreurs.Count > 0)
            {
                string messageErreur = "";
                foreach (string err in erreurs)
                {
                    messageErreur += "- " + err + "\n";
                }
                await DisplayAlert("Impossible de réserver :", messageErreur, "OK");
            }
            else
            {
                // Aucune erreur, procéder au paiement
                await Navigation.PushAsync(new Paiment(idFilm, libelle, (int)prix));
            }
        }
    }
}
