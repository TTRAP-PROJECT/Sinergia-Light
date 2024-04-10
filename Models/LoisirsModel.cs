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
    internal class LoisirsModel : INotifyPropertyChanged
    {
        API api;
        private ObservableCollection<Loisirs> _loisirsList;
        private string _filterText;

        public LoisirsModel()
        {
            api = new API();
            LoisirsList = new ObservableCollection<Loisirs>();
            LoadData();
            FilterCommand = new Command<string>(Filter);
        }

        public async Task LoadData()
        {
            var result = await api.GetPostData("/loisirs");
            List<Loisirs> loisirsList = JsonConvert.DeserializeObject<List<Loisirs>>(result);

            // Effacez la liste actuelle avant d'ajouter de nouveaux éléments
            LoisirsList.Clear();

            // Ajoutez les éléments à la liste LoisirsList
            foreach (var loisir in loisirsList)
            {
                LoisirsList.Add(loisir);
            }

            // Indiquez à l'interface utilisateur que la liste a été mise à jour
            OnPropertyChanged("LoisirsList");
        }

        public ObservableCollection<Loisirs> LoisirsList
        {
            get { return _loisirsList; }
            set
            {
                if (_loisirsList != value)
                {
                    _loisirsList = value;
                    OnPropertyChanged(nameof(LoisirsList));
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

            var filteredList = LoisirsList.Where(c => c.LibelleLoisir.ToLower().Contains(searchText.ToLower())).ToList();
            LoisirsList = new ObservableCollection<Loisirs>(filteredList);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
