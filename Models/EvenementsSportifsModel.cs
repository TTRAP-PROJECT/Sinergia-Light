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
    class EvenementsSportifsModel
    {
        API api;
        private ObservableCollection<EvenementsSportifs> _evenementsSportifsList;



        public EvenementsSportifsModel()
        {
            api = new API();
            EvenementsSportifsList = new ObservableCollection<EvenementsSportifs>();
            LoadData();
        }

        private async void LoadData()
        {
            var result = await api.GetPostData("/events/sport");
            List<EvenementsSportifs> servicesList = JsonConvert.DeserializeObject<List<EvenementsSportifs>>(result);

            foreach (var user in servicesList)
            {
                EvenementsSportifsList.Add(user);
            }
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

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
