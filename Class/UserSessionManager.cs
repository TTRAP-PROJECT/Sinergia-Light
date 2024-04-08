using firstMobileApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace firstMobileApp.Class
{
    // Classe pour gérer les informations de session de l'utilisateur
    public static class UserSessionManager
    {
        // Propriétés pour stocker les informations de l'utilisateur connecté
        public static int Id { get; private set; }
        public static string Email { get; private set; }
        public static int Solde { get; private set; }
        public static int NBCookies { get; private set; }
        public static string Nom { get; private set; }
        public static string Prenom { get; private set; }

        // Ajoutez d'autres informations de connexion si nécessaire

        // Méthode pour définir les informations de connexion une fois connecté
        public static void SetUser(string email)
        {
            Email = email;
            // Stockez les autres informations de connexion si nécessaire
        }

        // Méthode pour effacer les informations de connexion une fois déconnecté
        public static void ClearUser()
        {
            Email = null;
            // Effacez les autres informations de connexion si nécessaire
        }

        public async static void UpdateUserData()
        {
            UserModel userModel = new UserModel();
            await userModel.LoadData();
            Users user = userModel.User;

            if (user != null)
            {
                Id = user.IDUTILISATEUR;
                Solde = user.SOLDE;
                Prenom = user.PRENOMUTILISATEUR;
                Nom = user.NOMUTILISATEUR;
                NBCookies = user.NBCOOKIES;
            }

            
        }
        
    }
}
