using firstMobileApp.Class;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace firstMobileApp.Models
{
    public static class ExceptionModel
    {
        private static readonly API api = new API();
        public async static Task<List<bool>> EstReservable(int idService, int prix, DateTime DateService, int nbPlaceMax, int nbReservations, int idVendeur)
        {
            UserSessionManager.UpdateUserData();
            List<bool> liste = new List<bool>();
            if (DateService < DateTime.Now) { liste.Add(true); }//Date dépassée
            else { liste.Add(false); }
            int idUser = UserSessionManager.Id;
            var result = await api.GetPostData($"/reservation/{idUser}/{idService}");
            bool estReserve = JsonConvert.DeserializeObject<bool>(result);
            liste.Add(estReserve);//service deja reserve
            if (nbPlaceMax <= nbReservations) {  liste.Add(true); }//Plus de place :(
            else { liste.Add(false); }
            if (prix > UserSessionManager.Solde) { liste.Add(true); }//service trop cher, pas assez de credits
            else { liste.Add(false); }
            liste.Add(idVendeur == idUser);

            return liste;
        }

        public static async Task<bool> AnnulerReservation(int idResa)
        {
            int idUser = UserSessionManager.Id;
            var result = await api.GetPostData($"/reservation/cancel/{idResa}/{idUser}");
            return result.Contains("supprim");
        }

    }
}
