using firstMobileApp.Class;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace firstMobileApp.Models
{
    class EvenementSportifModel
    {
        API api;
        private EvenementsSportifs _evenementSportif;
        private int idSport;


        public EvenementSportifModel(int idSport)
        {
            api = new API();
            this.idSport = idSport;

        }

        public async Task LoadData()
        {
            var result = await api.GetPostData($"/events/sport/{idSport}");
            Sport = JsonConvert.DeserializeObject<EvenementsSportifs>(result);

        }

        public EvenementsSportifs Sport
        {
            get { return _evenementSportif; }
            set
            {
                if (_evenementSportif != value)
                {
                    _evenementSportif = value;
                    OnPropertyChanged(nameof(EvenementsSportifs));
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
