using System;
using System.Collections.Generic;
using GestionBoutiqueFlorale;

class Program
{
    static List<Utilisateur> utilisateurs = new List<Utilisateur>();
    static List<Fleur> fleurs = new List<Fleur>();
    static List<Bouquet> modelesBouquets = new List<Bouquet>();
    static List<Commande> commandes = new List<Commande>();

    static void Main(string[] args)
    {
        // Importer les fleurs depuis le fichier CSV
        var filename = "C:\\Users\\LENOVO\\Desktop\\fleurs_db.csv";
        fleurs = FleurImportation.ImporterFleurs(filename);

        bool quitter = false;
        while (!quitter)
        {
            AfficherMenuPrincipal();
            string choix = Console.ReadLine();

            switch (choix)
            {
                case "1":
                    GestionUtilisateurs();
                    break;
                case "2":
                    GestionFleurs();
                    break;
                case "3":
                    GestionBouquets();
                    break;
                case "4":
                    GestionCommandes();
                    break;
                case "5":
                    GestionFactures();
                    break;
                case "6":
                    quitter = true;
                    Console.WriteLine("Merci d'avoir utilisé l'application. Au revoir !");
                    break;
                default:
                    Console.WriteLine("Choix invalide. Veuillez réessayer.");
                    break;
            }
        }
    }

    static void AfficherMenuPrincipal()
    {
        Console.WriteLine("\n=== Menu Principal ===");
        Console.WriteLine("1. Gestion des utilisateurs");
        Console.WriteLine("2. Gestion des fleurs");
        Console.WriteLine("3. Gestion des bouquets");
        Console.WriteLine("4. Gestion des commandes");
        Console.WriteLine("5. Gestion des factures");
        Console.WriteLine("6. Quitter");
        Console.Write("Choisissez une option : ");
    }

    static void GestionUtilisateurs()
    {
        Console.WriteLine("\n=== Gestion des utilisateurs ===");
        Console.WriteLine("1. Ajouter un client");
        Console.WriteLine("2. Ajouter un vendeur");
        Console.WriteLine("3. Ajouter un fournisseur");
        Console.WriteLine("4. Afficher tous les utilisateurs");
        Console.Write("Choisissez une option : ");
        string choix = Console.ReadLine();

        switch (choix)
        {
            case "1":
                AjouterClient();
                break;
            case "2":
                AjouterVendeur();
                break;
            case "3":
                AjouterFournisseur();
                break;
            case "4":
                AfficherUtilisateurs();
                break;
            default:
                Console.WriteLine("Choix invalide.");
                break;
        }
    }

    static void AjouterClient()
    {
        Console.Write("Nom : ");
        string nom = Console.ReadLine();
        Console.Write("Prénom : ");
        string prenom = Console.ReadLine();
        Console.Write("Téléphone : ");
        int telephone = int.Parse(Console.ReadLine());
        Console.Write("Adresse : ");
        string adresse = Console.ReadLine();

        var client = new Client(nom, prenom, telephone, adresse);
        utilisateurs.Add(client);
        Console.WriteLine("Client ajouté avec succès !");
    }

    static void AjouterVendeur()
    {
        Console.Write("Nom : ");
        string nom = Console.ReadLine();
        Console.Write("Prénom : ");
        string prenom = Console.ReadLine();
        Console.Write("Téléphone : ");
        int telephone = int.Parse(Console.ReadLine());
        Console.Write("Adresse : ");
        string adresse = Console.ReadLine();

        var vendeur = new Vendeur(nom, prenom, telephone, adresse);
        utilisateurs.Add(vendeur);
        Console.WriteLine("Vendeur ajouté avec succès !");
    }

    static void AjouterFournisseur()
    {
        Console.Write("Nom : ");
        string nom = Console.ReadLine();
        Console.Write("Prénom : ");
        string prenom = Console.ReadLine();
        Console.Write("Téléphone : ");
        int telephone = int.Parse(Console.ReadLine());
        Console.Write("Adresse : ");
        string adresse = Console.ReadLine();

        var fournisseur = new Fournisseur(nom, prenom, telephone, adresse);
        utilisateurs.Add(fournisseur);
        Console.WriteLine("Fournisseur ajouté avec succès !");
    }

    static void AfficherUtilisateurs()
    {
        Console.WriteLine("\nListe des utilisateurs :");
        foreach (var utilisateur in utilisateurs)
        {
            Console.WriteLine($"- {utilisateur.GetType().Name} : {utilisateur.Nom} {utilisateur.Prenom}");
        }
    }

    static void GestionFleurs()
    {
        Console.WriteLine("\n=== Gestion des fleurs ===");
        FleurImportation.AfficherFleursDisponibles(fleurs);
    }

    static void GestionBouquets()
    {
        Console.WriteLine("\n=== Gestion des bouquets ===");
        Console.WriteLine("1. Créer un bouquet personnalisé");
        Console.WriteLine("2. Enregistrer un modèle de bouquet");
        Console.Write("Choisissez une option : ");
        string choix = Console.ReadLine();

        switch (choix)
        {
            case "1":
                var bouquet = Bouquet.CreerBouquetPersonnalise(fleurs);
                Console.WriteLine("Bouquet créé avec succès !");
                break;
            case "2":
                Console.Write("Nom du modèle : ");
                string nomModele = Console.ReadLine();
                var bouquetModele = Bouquet.CreerBouquetPersonnalise(fleurs);
                modelesBouquets.Add(bouquetModele);
                Console.WriteLine("Modèle de bouquet enregistré avec succès !");
                break;
            default:
                Console.WriteLine("Choix invalide.");
                break;
        }
    }

    static void GestionCommandes()
    {
        Console.WriteLine("\n=== Gestion des commandes ===");
        Console.WriteLine("1. Passer une commande");
        Console.WriteLine("2. Valider une commande");
        Console.WriteLine("3. Annuler une commande");
        Console.Write("Choisissez une option : ");
        string choix = Console.ReadLine();

        switch (choix)
        {
            case "1":
                PasserCommande();
                break;
            case "2":
                ValiderCommande();
                break;
            case "3":
                AnnulerCommande();
                break;
            default:
                Console.WriteLine("Choix invalide.");
                break;
        }
    }

    static void PasserCommande()
    {
        // Sélectionner un client et un vendeur
        Console.WriteLine("Sélectionnez un client :");
        AfficherUtilisateurs();
        int indexClient = int.Parse(Console.ReadLine()) - 1;

        Console.WriteLine("Sélectionnez un vendeur :");
        AfficherUtilisateurs();
        int indexVendeur = int.Parse(Console.ReadLine()) - 1;

        var client = utilisateurs[indexClient] as Client;
        var vendeur = utilisateurs[indexVendeur] as Vendeur;

        // Sélectionner des fleurs et des bouquets
        var fleursSelectionnees = new List<Fleur>();
        var bouquetsSelectionnes = new List<Bouquet>();

        Console.WriteLine("Ajouter des fleurs à la commande (tapez 'fin' pour terminer) :");
        FleurImportation.AfficherFleursDisponibles(fleurs);
        while (true)
        {
            string choixFleur = Console.ReadLine();
            if (choixFleur.ToLower() == "fin") break;
            fleursSelectionnees.Add(fleurs[int.Parse(choixFleur) - 1]);
        }

        Console.WriteLine("Ajouter des bouquets à la commande (tapez 'fin' pour terminer) :");
        foreach (var bouquet in modelesBouquets)
        {
            Console.WriteLine($"- {bouquet.Fleurs.Count} fleurs");
        }
        while (true)
        {
            string choixBouquet = Console.ReadLine();
            if (choixBouquet.ToLower() == "fin") break;
            bouquetsSelectionnes.Add(modelesBouquets[int.Parse(choixBouquet) - 1]);
        }

        // Créer la commande
        var commande = new Commande(commandes.Count + 1, client, vendeur, fleursSelectionnees, bouquetsSelectionnes);
        commandes.Add(commande);
        Console.WriteLine("Commande passée avec succès !");
    }

    static void ValiderCommande()
    {
        Console.WriteLine("Sélectionnez une commande à valider :");
        for (int i = 0; i < commandes.Count; i++)
        {
            Console.WriteLine($"{i + 1}. Commande {commandes[i].Client.Nom}");
        }
        int indexCommande = int.Parse(Console.ReadLine()) - 1;
        commandes[indexCommande].ValiderCommande();
    }

    static void AnnulerCommande()
    {
        Console.WriteLine("Sélectionnez une commande à annuler :");
        for (int i = 0; i < commandes.Count; i++)
        {
            Console.WriteLine($"{i + 1}. Commande {commandes[i].Client.Nom}");
        }
        int indexCommande = int.Parse(Console.ReadLine()) - 1;
        commandes[indexCommande].AnnulerCommande();
    }

    static void GestionFactures()
    {
        Console.WriteLine("\n=== Gestion des factures ===");
        Console.WriteLine("Sélectionnez une commande pour générer la facture :");
        for (int i = 0; i < commandes.Count; i++)
        {
            Console.WriteLine($"{i + 1}. Commande {commandes[i].Client.Nom}");
        }
        int indexCommande = int.Parse(Console.ReadLine()) - 1;
        PayerCommande(commandes[indexCommande]);
    }

    static void PayerCommande(Commande commande)
    {
        Console.WriteLine("Choisissez un mode de paiement :");
        Console.WriteLine("1. Carte de débit");
        Console.WriteLine("2. Carte de crédit");
        Console.WriteLine("3. Espèces");
        string choix = Console.ReadLine();

        string modePaiement = choix switch
        {
            "1" => "Carte de débit",
            "2" => "Carte de crédit",
            "3" => "Espèces",
            _ => "Inconnu"
        };

        var facture = new Facture(commande, modePaiement);
        facture.GenererFacture();
    }
}