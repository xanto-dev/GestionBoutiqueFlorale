using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBoutiqueFlorale
{
    public class Bouquet
    {
        public List<Fleur> Fleurs { get; set; }
        public string CartePersonnalise { get; set; }

        public Bouquet(List<Fleur> fleurs, string cartePersonnalise)
        {
           
            Fleurs = fleurs;
            CartePersonnalise = cartePersonnalise;
        }

        public double CalculerPrixTotal()
        {
            double prixTotal = Fleurs.Sum(f => f.PrixUnitaire);
            if (!string.IsNullOrEmpty(CartePersonnalise))
            {
                prixTotal += 1; // 1 $ pour la carte personnalisée
            }
            return prixTotal + 2; // 2 $ pour le labeur
        }

        public static Bouquet CreerBouquetPersonnalise(List<Fleur> fleursDisponibles)
        {
            var fleursSelectionnees = new List<Fleur>();
            bool continuer = true;

            while (continuer)
            {
                Console.WriteLine("Ajouter une fleur au bouquet (tapez 'fin' pour terminer) :");
                string choix = Console.ReadLine();

                if (choix.ToLower() == "fin")
                {
                    continuer = false;
                }
                else
                {
                    var fleur = fleursDisponibles.FirstOrDefault(f => f.Nom.Equals(choix, StringComparison.OrdinalIgnoreCase));
                    if (fleur != null)
                    {
                        fleursSelectionnees.Add(fleur);
                        Console.WriteLine($"{fleur.Nom} ajoutée au bouquet.");
                    }
                    else
                    {
                        Console.WriteLine("Fleur non trouvée.");
                    }
                }
            }

            Console.WriteLine("Ajouter une carte personnalisée (laisser vide pour aucune) :");
            string carte = Console.ReadLine();

            return new Bouquet(fleursSelectionnees, carte);
        }
        public static void EnregistrerModeleBouquet(Bouquet bouquet, string nomModele)
        {
            
            Console.WriteLine($"Modèle de bouquet '{nomModele}' enregistré.");
        }
    }
}
