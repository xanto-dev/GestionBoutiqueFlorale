using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration.Attributes;

namespace GestionBoutiqueFlorale
{
    public class Fleur
    {
        [Name("Nom")]
        public string Nom { get; set; }

        [Name("Prix Unitaire (CAD)")]
        public double PrixUnitaire { get; set; }

        [Name("Couleur")]
        public string CouleurDominante { get; set; }

        [Name("Caractéristiques")]
        public string Description { get; set; }

        public Fleur() { }

        public Fleur(string nom, double prixUnitaire, string couleurDominante, string description)
        {
            
            Nom = nom;
            PrixUnitaire = prixUnitaire;
            CouleurDominante = couleurDominante;
            Description = description;
        }
        public void AfficherDetails()
        {
            Console.WriteLine($"Nom: {Nom}, Prix: {PrixUnitaire} CAD, Couleur: {CouleurDominante}, Description: {Description}");
        }

    }
}
