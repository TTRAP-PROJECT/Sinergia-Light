using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace firstMobileApp.Class
{
    class Sondages
    {
        public int IdSondage { get; set; }
        public string NomSondage { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }

        [JsonProperty("votes_pour")]
        public int VotesPour { get; set; }
        [JsonProperty("votes_contre")]
        public int VotesContre { get; set; }
    }
}
