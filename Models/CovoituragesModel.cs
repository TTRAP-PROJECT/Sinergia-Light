
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
    internal class CovoituragesModel : INotifyPropertyChanged
    {
        API api;
        private ObservableCollection<Covoiturage> _covoituragesList;
        private string _filterText;

        public CovoituragesModel()
        {
            api = new API();
            CovoituragesList = new ObservableCollection<Covoiturage>();
            LoadData();
            FilterCommand = new Command<string>(Filter);
        }

        public async Task LoadData()
        {
            var result = await api.GetPostData("/covoiturages");
            List<Covoiturage> covoituragesList = JsonConvert.DeserializeObject<List<Covoiturage>>(result);

            // Effacez la liste actuelle avant d'ajouter de nouveaux éléments
            CovoituragesList.Clear();

            // Ajoutez les éléments à la liste CovoituragesList
            foreach (var covoiturage in covoituragesList)
            {
                CovoituragesList.Add(covoiturage);
            }

            // Indiquez à l'interface utilisateur que la liste a été mise à jour
            OnPropertyChanged("CovoituragesList");
        }

        public ObservableCollection<Covoiturage> CovoituragesList
        {
            get { return _covoituragesList; }
            set
            {
                if (_covoituragesList != value)
                {
                    _covoituragesList = value;
                    OnPropertyChanged(nameof(CovoituragesList));
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
            var filteredList = CovoituragesList.Where(c => c.LieuDepart.ToLower().Contains(searchText.ToLower()) || c.LieuArrivee.ToLower().Contains(searchText.ToLower())).ToList();
            CovoituragesList = new ObservableCollection<Covoiturage>(filteredList);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
