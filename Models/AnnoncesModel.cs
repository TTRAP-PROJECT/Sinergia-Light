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
    public class AnnoncesModel : INotifyPropertyChanged
    {
        API api;
        private ObservableCollection<Annonce> _annonceList;

        public AnnoncesModel()
        {
            api = new API();
            AnnoncesList = new ObservableCollection<Annonce>();
            LoadData();
        }

        private async void LoadData()
        {
            var result = await api.GetPostData("/annonces");
            List<Annonce> annonceList = JsonConvert.DeserializeObject<List<Annonce>>(result);

            foreach (var annonce in annonceList)
            {
                AnnoncesList.Add(annonce);
            }
        }

        public ObservableCollection<Annonce> AnnoncesList
        {
            get { return _annonceList; }
            set
            {
                if (_annonceList != value)
                {
                    _annonceList = value;
                    OnPropertyChanged(nameof(AnnoncesList));
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
