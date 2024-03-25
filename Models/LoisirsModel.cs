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
    internal class LoisirsModel : INotifyPropertyChanged
    {
        API api;
        private ObservableCollection<Loisirs> _loisirsList;



        public LoisirsModel()
        {
            api = new API();
            LoisirsList = new ObservableCollection<Loisirs>();
            LoadData();
        }

        private async void LoadData()
        {
            var result = await api.GetPostData("/services");
            List<Loisirs> loisirsList = JsonConvert.DeserializeObject<List<Loisirs>>(result);

            foreach (var user in loisirsList)
            {
                LoisirsList.Add(user);
            }
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

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
