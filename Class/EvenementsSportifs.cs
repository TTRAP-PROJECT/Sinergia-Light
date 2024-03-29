using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace firstMobileApp.Class
{
    public class EvenementsSportifs
    {
        [JsonProperty("IDSERVICE")]
        public int IdService { get; set; }

        [JsonProperty("IDSPORT")]
        public int IdSport { get; set; }

        [JsonProperty("LIEUEVENT")]
        public string LieuEvent { get; set; }

        [JsonProperty("DATEEVENT")]
        public DateTime DateEvent { get; set; }

        [JsonProperty("nom_sport")]
        public string NomSport { get; set; }

        [JsonProperty("s_p_o_r_t")]
        public Sports Sport { get; set; }
    }
}
