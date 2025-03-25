using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GestionBoutiqueFlorale
{
    public class Client : Utilisateur
    {
        [JsonIgnore]
        public List<Commande> Commandes { get; set; }

        public Client(string nom, string prenom, long telephone, string adresse)
            : base(nom, prenom, telephone, adresse)
        {
             Commandes= new List<Commande>();
        }

        public void PasserCommande(Commande commande)
        {
            Commandes.Add(commande);
            Console.WriteLine("Commande passée avec succès !");
        }
 
    }
}
