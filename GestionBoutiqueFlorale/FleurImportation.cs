using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;

namespace GestionBoutiqueFlorale
{
    public class FleurImportation
    {
        public static List<Fleur> ImporterFleurs(string cheminFichierCsv)
        {
            try
            {
                using var reader = new StreamReader(cheminFichierCsv);
                using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
                return csv.GetRecords<Fleur>().ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de la lecture du fichier CSV: {ex.Message}");
                return new List<Fleur>();
            }
        }
        public static void AfficherFleursDisponibles(List<Fleur> fleurs)
        {
            Console.WriteLine("Fleurs disponibles :");
            for (int i = 0; i < fleurs.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {fleurs[i].Nom} ({fleurs[i].CouleurDominante}) : {fleurs[i].PrixUnitaire} CAD");
            }
        }
    }

}

