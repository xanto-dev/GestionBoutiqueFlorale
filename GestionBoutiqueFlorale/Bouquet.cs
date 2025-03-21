using System.Collections.Generic;

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

        public static Bouquet CreerBouquetPersonnalise(List<Fleur> fleurs)
        {
            var fleursSelectionnees = new List<Fleur>();
            bool continuer = true;

            while (continuer)
            {
                AfficherFleursDisponibles(fleurs);
                Console.WriteLine("Ajouter une fleur au bouquet (tapez 'fin' pour terminer) :");
                string choix = Console.ReadLine();

                if (choix.ToLower() == "fin")
                {
                    continuer = false;
                }
                else
                {
                    if (int.TryParse(choix, out int index) && index >= 1 && index <= fleurs.Count)
                    {
                        fleursSelectionnees.Add(fleurs[index - 1]);
                        Console.WriteLine($"{fleurs[index - 1].Nom} ajoutée au bouquet.");
                    }
                    else
                    {
                        Console.WriteLine("Choix invalide. Veuillez réessayer.");
                    }
                }
            }

            Console.WriteLine("Ajouter une carte personnalisée (laisser vide pour aucune) :");
            string carte = Console.ReadLine();

            return new Bouquet(fleursSelectionnees, carte);
        }

        private static void AfficherFleursDisponibles(List<Fleur> fleurs)
        {
            Console.WriteLine("Fleurs disponibles :");
            for (int i = 0; i < fleurs.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {fleurs[i].Nom} ({fleurs[i].CouleurDominante}) : {fleurs[i].PrixUnitaire} CAD");
            }
        }
    }
}