using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace firstMobileApp.Class
{
    public class Annonces
    {
        public int IdAnnonce { get; set; }
        public int IdService { get; set; }
        public int IdUtilisateur { get; set; }
        public int IdUtilisateur1 { get; set; }
        public int IdUtilisateur2 { get; set; }
        public string TitreAnnonce { get; set; }
        public string DescriptionAnnonce { get; set; }
        public string CoutAnnonce { get; set; }
        public DateTime DatePublicationAnnonce { get; set; }
        public DateTime DateTransaction { get; set; }
        public DateTime DatePrevue { get; set; }
    }
}
