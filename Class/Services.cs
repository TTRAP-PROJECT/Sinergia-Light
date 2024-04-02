using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace firstMobileApp.Class
{
    public class Services
    {
        public int IdService { get; set; }

        public int IdStatut { get; set; }

        public string LibelleService { get; set; }

        public int TypeService { get; set; }

        public string Description { get; set; }

        public decimal Prix { get; set; }

        [JsonProperty("LIEU_SERVICE")]
        public string LieuService { get; set; }

        public int IdVendeur { get; set; }

        public int? IdModerateur { get; set; }

        public DateTime DatePublication { get; set; }

        public DateTime DatePrevue { get; set; }

        public int NbPersonnesMax { get; set; }
    }
}
