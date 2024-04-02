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
    class FilmModel
    {
        API api;
        private Cinema _cinema;
        private int idFilm;


        public FilmModel(int idFilm)
        {
            api = new API();
            this.idFilm = idFilm;

        }

        public async Task LoadData()
        {
            var result = await api.GetPostData($"/events/cinema/{idFilm}");
            Film = JsonConvert.DeserializeObject<Cinema>(result);

        }

        public Cinema Film
        {
            get { return _cinema; }
            set
            {
                if (_cinema != value)
                {
                    _cinema = value;
                    OnPropertyChanged(nameof(Cinema));
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
