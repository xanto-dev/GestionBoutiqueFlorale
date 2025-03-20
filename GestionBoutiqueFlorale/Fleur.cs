using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;

namespace GestionBoutiqueFlorale
{
    public class Fleur
    {
        public string Nom { get; set; }
        public double PrixUnitaire { get; set; }
        public string CouleurDominante { get; set; }
        public string Description { get; set; }

        public Fleur() { }

        public Fleur(string nom, double prixUnitaire, string couleurDominante, string description)
        {
            
            Nom = nom;
            PrixUnitaire = prixUnitaire;
            CouleurDominante = couleurDominante;
            Description = description;
        }
        
    }
}
