using System;
using System.Collections.Generic;

namespace GestionBoutiqueFlorale
{
    class Program
    {
        static List<Client> clients = new List<Client>();
        static List<Vendeur> vendeurs = new List<Vendeur>();
        static List<Fournisseur> fournisseurs = new List<Fournisseur>();
        static List<Proprietaire> proprietaires = new List<Proprietaire>();
        static List<Fleur> fleurs = new List<Fleur>();
        static List<Bouquet> modelesBouquets = new List<Bouquet>();
        static List<Commande> commandes = new List<Commande>();

        static void Main(string[] args)
        {
            // Charger les données (créera le fichier JSON s'il n'existe pas)
            var data = DataManager.Charger();

            clients = data.clients ?? new List<Client>();
            vendeurs = data.vendeurs ?? new List<Vendeur>();
            fournisseurs = data.fournisseurs ?? new List<Fournisseur>();
            proprietaires = data.proprietaires ?? new List<Proprietaire>();
            modelesBouquets = data.ModelesBouquets ?? new List<Bouquet>();
            commandes = data.Commandes ?? new List<Commande>();

          
            // Importer les fleurs depuis le fichier CSV
            var filename = "fleurs_db.csv";
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

        // Sauvegarder les modifications
        static void SauvegarderData()
        {
            DataManager.Sauvegarder(new DataManager.AppData
            {
                clients = clients,
                vendeurs = vendeurs,
                fournisseurs = fournisseurs,
                proprietaires = proprietaires,
                ModelesBouquets = modelesBouquets,
                Commandes = commandes
            });
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
                    AfficherClients();
                    AfficherVendeurs();
                    AfficherFournisseurs();
                    AfficherProprietaires();
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
            clients.Add(client);
            SauvegarderData();
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
            vendeurs.Add(vendeur);
            SauvegarderData();
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
            fournisseurs.Add(fournisseur);
            SauvegarderData();
            Console.WriteLine("Fournisseur ajouté avec succès !");
        }

        static void AfficherVendeurs()
        {
            Console.WriteLine("\nListe des vendeurs :");
            foreach (var vendeur in vendeurs)
            {
                Console.WriteLine($"- {vendeur.Nom}, {vendeur.Prenom}");
            }
        }
        static void AfficherClients()
        {
            Console.WriteLine("\nListe des clients :");
            foreach (var client in clients)
            {
                Console.WriteLine($"- {client.Nom}, {client.Prenom}");
            }
        }
        static void AfficherFournisseurs()
        {
            Console.WriteLine("\nListe des fournisseurs :");
            foreach (var fournisseur in fournisseurs)
            {
                Console.WriteLine($"- {fournisseur.Nom}, {fournisseur.Prenom}");
            }
        }
        static void AfficherProprietaires()
        {
            Console.WriteLine("\nListe des proprietaires :");
            foreach (var proprietaire in proprietaires)
            {
                Console.WriteLine($"- {proprietaire.Nom}, {proprietaire.Prenom}");
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
            Console.Write("Choisissez une option : ");
            string choix = Console.ReadLine();

            switch (choix)
            {
                case "1":
                    var bouquetModele = Bouquet.CreerBouquetPersonnalise(fleurs);
                    modelesBouquets.Add(bouquetModele);
                    Console.WriteLine("Modèle de bouquet enregistré avec succès !");
                    SauvegarderData();
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
            AfficherClients();
            int indexClient = int.Parse(Console.ReadLine()) - 1;

            Console.WriteLine("Sélectionnez un vendeur :");
            AfficherVendeurs();
            int indexVendeur = int.Parse(Console.ReadLine()) - 1;

            var client = clients[indexClient] as Client;
            var vendeur = vendeurs[indexVendeur] as Vendeur;

            // Sélectionner des fleurs et des bouquets
            var fleursSelectionnees = new List<Fleur>();
            var bouquetsSelectionnes = new List<Bouquet>();

            FleurImportation.AfficherFleursDisponibles(fleurs);
            Console.WriteLine("Ajouter des fleurs à la commande (tapez 'fin' pour terminer) :");
           
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
            SauvegarderData();
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
}