using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBoutiqueFlorale
{
    public class Vendeur : Utilisateur
    {
        public bool EstValidee { get; set; }
        public Vendeur(string nom, string prenom, int telephone, string adresse) : base(nom, prenom, telephone, adresse) { }
       

    }
}
