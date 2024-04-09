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
    public class EvenementsSportifsModel : INotifyPropertyChanged
    {
        API api;
        private ObservableCollection<EvenementsSportifs> _evenementsSportifsList;
        private string _filterText;

        public EvenementsSportifsModel()
        {
            api = new API();
            EvenementsSportifsList = new ObservableCollection<EvenementsSportifs>();
            LoadData();
            FilterCommand = new Command<string>(Filter);
        }

        public async void LoadData()
        {
            var result = await api.GetPostData("/events/sport");
            List<EvenementsSportifs> evenementsSportifs = JsonConvert.DeserializeObject<List<EvenementsSportifs>>(result);

            // Effacez la liste actuelle avant d'ajouter de nouveaux éléments
            EvenementsSportifsList.Clear();

            // Ajoutez les éléments à la liste CinemaList
            foreach (var evenementSportif in evenementsSportifs)
            {
                EvenementsSportifsList.Add(evenementSportif);
            }

            // Indiquez à l'interface utilisateur que la liste a été mise à jour
            OnPropertyChanged("EvenementsSportifsList");
        }

        public ObservableCollection<EvenementsSportifs> EvenementsSportifsList
        {
            get { return _evenementsSportifsList; }
            set
            {
                if (_evenementsSportifsList != value)
                {
                    _evenementsSportifsList = value;
                    OnPropertyChanged(nameof(EvenementsSportifsList));
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

            var filteredList = EvenementsSportifsList.Where(c => c.LibelleSport.ToLower().Contains(searchText.ToLower())).ToList();
            EvenementsSportifsList = new ObservableCollection<EvenementsSportifs>(filteredList);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
