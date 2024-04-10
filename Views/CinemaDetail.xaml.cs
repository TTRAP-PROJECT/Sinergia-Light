using firstMobileApp.Class;
using firstMobileApp.Models;

namespace firstMobileApp.Views
{
    public partial class CinemaDetail : ContentPage
    {
        FilmModel filmModel;
        ToolbarItem soldeToolbarItem;
        public CinemaDetail(int idFilm)
        {
            InitializeComponent();
            InitializeAsync(idFilm);
            soldeToolbarItem = new ToolbarItem();
            soldeToolbarItem.Text = UserSessionManager.Solde.ToString() + "💰"; // Remplacez 100 par le solde réel de l'utilisateur
            ToolbarItems.Add(soldeToolbarItem);
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            // Appeler la méthode de rafraîchissement des données lorsque la page apparaît
            await filmModel.LoadData();
            await UserSessionManager.UpdateUserData();
            soldeToolbarItem.Text = UserSessionManager.Solde.ToString() + "💰";
            nb.Text = "Réservations : " + filmModel.Film.NombreDeReservations.ToString() + " / " + filmModel.Film.Service.NbPersonnesMax.ToString();
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
            var idVendeur = filmModel.Film.Service.IdVendeur;


            // Appelez votre méthode EstReservable pour vérifier si la réservation est possible
            List<bool> listeBools = await ExceptionModel.EstReservable(idFilm, (int)prix, date, nbReservationMax, nbReservation, idVendeur);

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
            if (listeBools[4])
            {
                erreurs.Add("Vous êtes le propriétaire de ce service.");
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
