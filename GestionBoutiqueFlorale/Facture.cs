using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBoutiqueFlorale
{
    public class Facture
    {
        public Commande Commande { get; set; }
        public string ModePaiement { get; set; }

        public Facture(Commande commande, string modePaiement)
        {
            
            Commande = commande;
            ModePaiement = modePaiement;
            
        }
        public void GenererFacture()
        {
           
            Console.WriteLine("=== Facture ===");
            Console.WriteLine($"Client : {Commande.Client.Nom} {Commande.Client.Prenom}");
            Console.WriteLine($"Vendeur : {Commande.Vendeur.Nom} {Commande.Vendeur.Prenom}");
            Console.WriteLine("Articles :");

            foreach (var fleur in Commande.Fleurs)
            {
                Console.WriteLine($"- {fleur.Nom} : {fleur.PrixUnitaire} CAD");
            }

            foreach (var bouquet in Commande.Bouquets)
            {
                Console.WriteLine($"- Bouquet : {bouquet.CalculerPrixTotal()} CAD");
            }

            Console.WriteLine($"Montant total : {Commande.MontantTotal} CAD");
            Console.WriteLine($"Mode de paiement : {ModePaiement}");
            Console.WriteLine("Merci pour votre achat !");
        }

    }
}
