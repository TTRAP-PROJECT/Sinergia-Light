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
    class CovoiturageModel
    {
        API api;
        private Covoiturage _covoiturage;
        private int idTrajet;


        public CovoiturageModel(int idTrajet)
        {
            api = new API();
            this.idTrajet = idTrajet;

        }

        public async Task LoadData()
        {
            var result = await api.GetPostData($"/covoiturage/{idTrajet}");
            Trajet = JsonConvert.DeserializeObject<Covoiturage>(result);

        }

        public Covoiturage Trajet
        {
            get { return _covoiturage; }
            set
            {
                if (_covoiturage != value)
                {
                    _covoiturage = value;
                    OnPropertyChanged(nameof(Covoiturage));
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
