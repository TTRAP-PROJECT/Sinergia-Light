using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace firstMobileApp.Class
{
    public class Covoiturage
    {
        public int IdService { get; set; }
        public string LieuDepart { get; set; }
        public string LieuArrivee { get; set; }
        public DateTime DateCovoit { get; set; }
        public int NombreDeReservations { get; set; }
        [JsonProperty("s_e_r_v_i_c_e")]
        public Services Service { get; set; }
    }
}
