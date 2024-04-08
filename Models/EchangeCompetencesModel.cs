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
    class EchangeCompetencesModel
    {
        API api;
        private EchangeCompetences _echangeCompetences;
        private int idCours;


        public EchangeCompetencesModel(int idCours)
        {
            api = new API();
            this.idCours = idCours;

        }

        public async Task LoadData()
        {
            var result = await api.GetPostData($"/echangeCompetence/{idCours}");
            Cours = JsonConvert.DeserializeObject<EchangeCompetences>(result);

        }

        public EchangeCompetences Cours
        {
            get { return _echangeCompetences; }
            set
            {
                if (_echangeCompetences != value)
                {
                    _echangeCompetences = value;
                    OnPropertyChanged(nameof(EchangeCompetences));
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
