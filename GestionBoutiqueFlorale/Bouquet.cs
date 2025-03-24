using System.Collections.Generic;

namespace GestionBoutiqueFlorale
{
    public class Bouquet
    {
        public string NomBouquet { get; set; }
        public List<Fleur> Fleurs { get; set; }
        public string CartePersonnalise { get; set; }

        public Bouquet(string nomBouquet, List<Fleur> fleurs, string cartePersonnalise)
        {
            NomBouquet = nomBouquet;
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
                Console.WriteLine("Entrez un numero pour choisir une fleur a ajouter (tapez 'fin' pour terminer) :");
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

            Console.Write("Entrer Nom du modèle : ");
            string nomModele = Console.ReadLine();

            return new Bouquet(nomModele, fleursSelectionnees, carte);
        }

        public static void AfficherFleursDisponibles(List<Fleur> fleurs)
        {
            Console.WriteLine("Fleurs disponibles :");
            for (int i = 0; i < fleurs.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {fleurs[i].Nom} ({fleurs[i].CouleurDominante}) : {fleurs[i].PrixUnitaire} CAD");
            }
        }
    }
}