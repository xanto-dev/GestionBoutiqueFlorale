using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBoutiqueFlorale
{
    public class Fournisseur : Utilisateur
    {
        public Fournisseur(string nom, string prenom, int telephone, string adresse) : base(nom, prenom, telephone, adresse) { }
    }
}
