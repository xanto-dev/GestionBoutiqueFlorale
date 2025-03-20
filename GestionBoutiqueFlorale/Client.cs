using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBoutiqueFlorale
{
    public class Client : Utilisateur
    {
        public List<Commande> Commandes { get; set; }

        public Client(string nom, string prenom, int telephone, string adresse)
            : base(nom, prenom, telephone, adresse)
        {
            Commandes = new List<Commande>();
        }

        public void PasserCommande(Commande commande)
        {
            Commandes.Add(commande);
            Console.WriteLine("Commande passée avec succès !");
        }
 
    }
}
