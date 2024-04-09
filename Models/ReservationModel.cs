using firstMobileApp.Class;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace firstMobileApp.Models
{
    public class ReservationModel : INotifyPropertyChanged
    {
        API api;
        private ObservableCollection<Reservation> _reservationList;

        public ReservationModel()
        {
            api = new API();
            ReservationList = new ObservableCollection<Reservation>();
            LoadData();
        }

        public async void LoadData()
        {
            var idUser = UserSessionManager.Id;
            var result = await api.GetPostData($"/reservation/{idUser}");
            List<Reservation> reservationsList = JsonConvert.DeserializeObject<List<Reservation>>(result);

            // Effacez la liste actuelle avant d'ajouter de nouveaux éléments
            ReservationList.Clear();

            // Ajoutez les éléments à la liste ReservationList
            foreach (var reservation in reservationsList)
            {
                ReservationList.Add(reservation);
            }

            // Indiquez à l'interface utilisateur que la liste a été mise à jour
            OnPropertyChanged(nameof(ReservationList));
        }

        public ObservableCollection<Reservation> ReservationList
        {
            get { return _reservationList; }
            set
            {
                if (_reservationList != value)
                {
                    _reservationList = value;
                    OnPropertyChanged(nameof(ReservationList));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
