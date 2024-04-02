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
    internal class SondagesModel : INotifyPropertyChanged
    {
        API api;
        private ObservableCollection<Sondages> _sondagesList;
        private string _filterText;

        public SondagesModel()
        {
            api = new API();
            SondagesList = new ObservableCollection<Sondages>();
            LoadData();
            FilterCommand = new Command<string>(Filter);
        }

        public async void LoadData()
        {
            var result = await api.GetPostData("/sondages");
            List<Sondages> sondagesList = JsonConvert.DeserializeObject<List<Sondages>>(result);

            // Effacez la liste actuelle avant d'ajouter de nouveaux éléments
            SondagesList.Clear();

            // Ajoutez les éléments à la liste CinemaList
            foreach (var sondages in sondagesList)
            {
                SondagesList.Add(sondages);
            }

            // Indiquez à l'interface utilisateur que la liste a été mise à jour
            OnPropertyChanged("CinemaList");
        }

        public ObservableCollection<Sondages> SondagesList
        {
            get { return _sondagesList; }
            set
            {
                if (_sondagesList != value)
                {
                    _sondagesList = value;
                    OnPropertyChanged(nameof(SondagesList));
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

            var filteredList = SondagesList.Where(s => s.NomSondage.ToLower().Contains(searchText.ToLower())).ToList();
            SondagesList = new ObservableCollection<Sondages>(filteredList);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
