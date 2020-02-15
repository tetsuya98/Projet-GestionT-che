using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjetGestionTaches.Models
{
    class Annuaire
    {
        readonly public GestionTachesContext context;
        public Annuaire(GestionTachesContext c)
        {
            context = c;
        }
        public GestionTachesContext GetContext() { return context; }
        //fonction d'ajout d'un utilisateur
        public Utilisateur AddUtilisateur(String un, String n, String p)
        {
            //creation d'un nouveau utilisateur avec le param saisie
            Utilisateur newUser = new Utilisateur()
            {
                UserName = un,
                Nom = n,
                Prenom = p
            };
            //ajout du nouvel utilisateur a l'anuaire
            context.Annuaire.Add(newUser);
            //sauvegarde l'utilisateur dans la bd
            context.SaveChanges();
            return newUser;
        }

        //fonction de supression d'un utilisateur
        public Boolean RemoveUtilisateur(int id)
        {
            //recherche de l'utilisateur
            Utilisateur u = context.Annuaire.Find(id);
            //si l'utilisateur n'existe pas
            if (u is null)
            {
                return false;
            }
            else //sinon
            {
                //supression de l'utilisateur dans l'annuaire
                context.Annuaire.Remove(u);
                //sauvegarde des changement dans la bd
                context.SaveChanges();
                return true;
            }
        }

        //fonction de modification d'un utilisateur
        public Boolean ModifyUtilisateur(int id, String un, String n, String p)
        {
            //recherche de l'utilisateur
            Utilisateur u = context.Annuaire.Find(id);
            //si l'utilisateur n'existe pas
            if (u is null)
            {
                return false;
            }
            else //sinon
            {
                u.UserName = un;
                u.Nom = n;
                u.Prenom = p;
                //modification de l'utilisateur dans l'annuaire
                context.Attach(u).State = EntityState.Modified;
                //sauvegarde des changements dans la bd
                context.SaveChanges();
                return true;
            }
        }

        public Utilisateur GetUtilisateur(int id)
        {
            return context.Annuaire.Find(id);
        }
        public async Task<List<Utilisateur>> GetUtilisateurs()
        {
            return await context.Annuaire.ToListAsync();
        }
    }
}