using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace firstMobileApp.Class
{
    public class Cinema
    {
        public int IdService { get; set; }
        public string LieuFilm { get; set; }
        public string NomFilm { get; set; }
        public DateTime DateHeureFilm { get; set; }

        [JsonProperty("s_e_r_v_i_c_e")]
        public Services Service { get; set; }
    }
}
