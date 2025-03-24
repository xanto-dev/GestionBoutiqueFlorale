using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GestionBoutiqueFlorale
{

    public abstract class Utilisateur
    {
        public string Nom { get; set; }
        public string Prenom{ get; set; }
        public int Telephone { get; set; }
        public string Adresse { get; set; }

        public Utilisateur(string nom, string prenom, int telephone, string adresse )
        {
            
            Nom = nom;
            Prenom = prenom;
            Telephone = telephone;
            Adresse = adresse;
        }
        public void AfficherUtilisateurs()
        {
            Console.WriteLine($"Nom: {Nom}, Prénom: {Prenom}, Téléphone: {Telephone}, Adresse: {Adresse}");
        }

    }

}
