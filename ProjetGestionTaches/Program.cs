using ProjetGestionTaches.Models;
using System;

namespace ProjetGestionTaches
{
    class Program
    {
        static void Main(string[] args)
        {
            GestionTachesContext context = new GestionTachesContext();

            // Initialisation du modèle
            Annuaire AnnuaireUtilisateurs = new Annuaire(context);
            Registre BaseRegistres = new Registre(context);
            GestionTache GestionnaireTaches = new GestionTache();

            Tache.lastPID = 1;
            Utilisateur user;
            ElementRegistre entry;

            user = AnnuaireUtilisateurs.GetUtilisateur(1);
            entry = BaseRegistres.GetElementRegistre(1);
            Tache tache = GestionnaireTaches.AjouterTache(user, entry);
            entry = BaseRegistres.GetElementRegistre(2);
            tache = GestionnaireTaches.AjouterTache(user, entry);
            user = AnnuaireUtilisateurs.GetUtilisateur(2);
            entry = BaseRegistres.GetElementRegistre(1);
            tache = GestionnaireTaches.AjouterTache(user, entry);

            Console.ReadKey();
        }
    }
}