using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBoutiqueFlorale
{
    public class Commande
    {
        public Client Client { get; set; }
        public Vendeur Vendeur { get; set; }
        public List<Fleur> Fleurs { get; set; }
        public List<Bouquet> Bouquets { get; set; }
        public double MontantTotal { get; set; }
        public bool EstValidee { get; set; }

        public Commande(int id, Client client, Vendeur vendeur, List<Fleur> fleurs, List<Bouquet> bouquets)
        {
          
            Client = client;
            Vendeur = vendeur;
            Fleurs = fleurs;
            Bouquets = bouquets;
            MontantTotal = CalculerMontantTotal();
            EstValidee = false;
        }

        public double CalculerMontantTotal()
        {
            double montantFleurs = Fleurs.Sum(f => f.PrixUnitaire);
            double montantBouquets = Bouquets.Sum(b => b.CalculerPrixTotal());
            return montantFleurs + montantBouquets;
        }

        public void ValiderCommande()
        {
            EstValidee = true;
            Console.WriteLine("Commande validée.");
        }

        public void AnnulerCommande()
        {
            EstValidee = false;
            Console.WriteLine("Commande annulée.");
        }
    }
}
