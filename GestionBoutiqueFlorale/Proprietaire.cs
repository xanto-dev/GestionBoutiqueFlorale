using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBoutiqueFlorale
{
    public class Proprietaire : Utilisateur
    {
         public Proprietaire(string nom, string prenom, Int64 telephone, string adresse) : base(nom, prenom, telephone, adresse) { }

        public override void AfficherProfil()
        {
            Console.WriteLine($"{Nom} {Prenom}");

        }
    }


}
