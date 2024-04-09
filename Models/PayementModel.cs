using firstMobileApp.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace firstMobileApp.Models
{
    internal class PaymentModel
    {
        API api;
        int idService;
        int idUser;
        public bool aFonctionne;


        public PaymentModel(int idService)
        {
            api = new API();
            this.idService = idService;
            idUser = UserSessionManager.Id;
        }
        public async Task PostData()
        {
            // Créer un objet pour stocker les données à envoyer dans le corps de la requête

            // Appeler la méthode PostData de votre API en passant le chemin d'URL et les données JSON
            var result = await api.PostData($"/reserver/{idUser}/{idService}", "{}");
            if (result.Contains("IDACHETEUR") && result.Contains("IDSERVICE") && result.Contains("IDRESERVATION"))
            {
                // La réservation a réussi
                aFonctionne = true;
            }
            else
            {
                // La réservation a échoué
                aFonctionne = false;
            }
        }
    }
}
