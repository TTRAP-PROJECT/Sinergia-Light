using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace firstMobileApp.Class
{
    public class Reservation
    {
        public int IdReservation { get; set; }
        public int IdAcheteur { get; set; }
        public DateTime DateTransaction { get; set; }
        public Services Service { get; set; }
    }
}
