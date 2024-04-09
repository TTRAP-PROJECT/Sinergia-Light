using firstMobileApp.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace firstMobileApp.Models
{
    internal class VoteModel
    {
        API api;
        int idUser;


        public VoteModel()
        {
            api = new API();
            idUser = UserSessionManager.Id;
        }
        public async Task<string> VoterPour(int idSondage)
        {
            // Créer un objet pour stocker les données à envoyer dans le corps de la requête

            // Appeler la méthode PostData de votre API en passant le chemin d'URL et les données JSON
            return await api.GetPostData($"/sondage/votePour/{idSondage}/{idUser}");
            
        }
        public async Task<string> VoterContre(int idSondage)
        {
            // Créer un objet pour stocker les données à envoyer dans le corps de la requête

            // Appeler la méthode PostData de votre API en passant le chemin d'URL et les données JSON
            return await api.GetPostData($"/sondage/voteContre/{idSondage}/{idUser}");
        }
    }
}
