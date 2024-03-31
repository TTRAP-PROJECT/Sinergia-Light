using firstMobileApp.Class;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace firstMobileApp.Models
{
    
    internal class ConnectionModel
    {
        API api;
        string login;
        string password;
        public bool estValide;


        public ConnectionModel(string login, string password)
        {
            api = new API();
            
            this.login = login;
            this.password = password;
            estValide = false;
            
        }
        public async Task LoadData()
        {
            // Créer un objet pour stocker les données à envoyer dans le corps de la requête

            // Appeler la méthode PostData de votre API en passant le chemin d'URL et les données JSON
            var result = await api.PostData($"/user/validation?email={login}&password={password}", "{}");

            // Désérialiser la réponse de la requête
            estValide = result == "true";
        }
    }
}
