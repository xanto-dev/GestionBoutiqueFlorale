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
        public Int64 Telephone { get; set; }
        public string Adresse { get; set; }

        public Utilisateur(string nom, string prenom, Int64 telephone, string adresse )
        {
            
            Nom = nom;
            Prenom = prenom;
            Telephone = telephone;
            Adresse = adresse;
        }


    }

}
