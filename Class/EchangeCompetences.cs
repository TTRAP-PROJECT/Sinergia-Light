using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace firstMobileApp.Class
{
    public class EchangeCompetences
    {
        public int IdService { get; set; }
        public string Matiere { get; set; }
        public int IdNiveau { get; set; }
        public int NombreDeReservations { get; set; }
        [JsonProperty("n_i_v_e_a_u")]
        public Niveau Niveau { get; set; }
        [JsonProperty("s_e_r_v_i_c_e")]
        public Services Service { get; set; }
        
    }
}
