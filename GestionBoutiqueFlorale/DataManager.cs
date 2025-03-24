using System;
using System.Collections.Generic;
using System.IO;
using GestionBoutiqueFlorale;
using Newtonsoft.Json;

public static class DataManager
{
    private static string filePath = "data.json";

    // Classe contenant toutes les listes
    public class AppData
    {
        public List<Client> clients { get; set; } = new List<Client>();
        public List<Vendeur> vendeurs { get; set; } = new List<Vendeur>();
        public List<Fournisseur> fournisseurs { get; set; } = new List<Fournisseur>();
        public List<Proprietaire> proprietaires { get; set; } = new List<Proprietaire>();
        public List<Bouquet> ModelesBouquets { get; set; } = new List<Bouquet>();
        public List<Commande> Commandes { get; set; } = new List<Commande>();
    }

    // Vérifie si le fichier JSON existe, sinon le crée avec des listes vides
    public static AppData Charger()
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine("Fichier JSON non trouvé. Création d'un nouveau...");
            AppData newData = new AppData();
            Sauvegarder(newData);
            return newData;
        }

        // Lire et charger le fichier JSON existant
        string json = File.ReadAllText(filePath);
        return JsonConvert.DeserializeObject<AppData>(json);
    }

    // Sauvegarde des données dans un fichier JSON
    public static void Sauvegarder(AppData data)
    {
        string json = JsonConvert.SerializeObject(data, Formatting.Indented);
        File.WriteAllText(filePath, json);
    }
}
