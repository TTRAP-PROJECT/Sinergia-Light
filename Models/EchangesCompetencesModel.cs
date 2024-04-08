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
    internal class EchangesCompetencesModel : INotifyPropertyChanged
    {
        API api;
        private ObservableCollection<EchangeCompetences> _echangeCompetencesList;
        private string _filterText;

        public EchangesCompetencesModel()
        {
            api = new API();
            EchangeCompetencesList = new ObservableCollection<EchangeCompetences>();
            LoadData();
            FilterCommand = new Command<string>(Filter);
        }

        public async void LoadData()
        {
            var result = await api.GetPostData("/echangeCompetences");
            List<EchangeCompetences> echangesCompetences = JsonConvert.DeserializeObject<List<EchangeCompetences>>(result);

            // Effacez la liste actuelle avant d'ajouter de nouveaux éléments
            EchangeCompetencesList.Clear();

            // Ajoutez les éléments à la liste CinemaList
            foreach (var echangeCompetences in echangesCompetences)
            {
                EchangeCompetencesList.Add(echangeCompetences);
            }

            // Indiquez à l'interface utilisateur que la liste a été mise à jour
            OnPropertyChanged("EchangeCompetencesList");
        }

        public ObservableCollection<EchangeCompetences> EchangeCompetencesList
        {
            get { return _echangeCompetencesList; }
            set
            {
                if (_echangeCompetencesList != value)
                {
                    _echangeCompetencesList = value;
                    OnPropertyChanged(nameof(EchangeCompetencesList));
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

            var filteredList = EchangeCompetencesList.Where(c => c.Matiere.ToLower().Contains(searchText.ToLower())).ToList();
            EchangeCompetencesList = new ObservableCollection<EchangeCompetences>(filteredList);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
