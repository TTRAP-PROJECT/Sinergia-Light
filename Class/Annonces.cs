using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace firstMobileApp.Class
{
    public class Annonce
    {
        [JsonProperty("ID_ANNONCE")]
        public int Id { get; set; }

        [JsonProperty("TITRE_ANNONCE")]
        public string Titre { get; set; }

        [JsonProperty("DESCRIPTION_ANNONCE")]
        public string Description { get; set; }

        [JsonProperty("DATE_PUBLICATION")]
        public DateTime DatePublication { get; set; }

        [JsonProperty("ID_MODERATEUR")]
        public int IdModerateur { get; set; }
    }
}
