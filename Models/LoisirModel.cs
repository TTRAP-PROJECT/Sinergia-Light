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
    class LoisirModel
    {
        API api;
        private Loisirs _loisir;
        private int idLoisir;


        public LoisirModel(int idLoisir)
        {
            api = new API();
            this.idLoisir = idLoisir;

        }

        public async Task LoadData()
        {
            var result = await api.GetPostData($"/loisir/{idLoisir}");
            Loisir = JsonConvert.DeserializeObject<Loisirs>(result);

        }

        public Loisirs Loisir
        {
            get { return _loisir; }
            set
            {
                if (_loisir != value)
                {
                    _loisir = value;
                    OnPropertyChanged(nameof(Loisirs));
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
