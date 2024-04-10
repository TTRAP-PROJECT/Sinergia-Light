using firstMobileApp.Class;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace firstMobileApp.Models
{
    internal class CinemaModel : INotifyPropertyChanged
    {
        API api;
        private ObservableCollection<Cinema> _cinemaList;
        private string _filterText;

        public CinemaModel()
        {
            api = new API();
            CinemaList = new ObservableCollection<Cinema>();
            LoadData();
            FilterCommand = new Command<string>(Filter);
        }

        public async Task LoadData()
        {
            var result = await api.GetPostData("/events/cinema");
            List<Cinema> cinemaList = JsonConvert.DeserializeObject<List<Cinema>>(result);

            // Effacez la liste actuelle avant d'ajouter de nouveaux éléments
            CinemaList.Clear();

            // Ajoutez les éléments à la liste CinemaList
            foreach (var cinema in cinemaList)
            {
                CinemaList.Add(cinema);
            }

            // Indiquez à l'interface utilisateur que la liste a été mise à jour
            OnPropertyChanged("CinemaList");
        }

        public ObservableCollection<Cinema> CinemaList
        {
            get { return _cinemaList; }
            set
            {
                if (_cinemaList != value)
                {
                    _cinemaList = value;
                    OnPropertyChanged(nameof(CinemaList));
                }
            }
        }

        public string FilterText
        {
            get { return _filterText; }
            set
            {
                if (_filterText != value)
                {
                    _filterText = value;
                    OnPropertyChanged(nameof(FilterText));
                }
            }
        }

        public ICommand FilterCommand { get; }

        private void Filter(string searchText)
        {
            if (string.IsNullOrWhiteSpace(searchText))
            {
                LoadData(); // Si la barre de recherche est vide, chargez toutes les données
                return;
            }

            var filteredList = CinemaList.Where(c => c.NomFilm.ToLower().Contains(searchText.ToLower())).ToList();
            CinemaList = new ObservableCollection<Cinema>(filteredList);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
