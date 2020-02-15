using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjetGestionTaches.Models
{
    class Registre
    {
        readonly public GestionTachesContext context;
        public Registre(GestionTachesContext c)
        {
            context = c;
        }
        public GestionTachesContext GetContext() { return context; }
        //fonction d'ajout d'un ElementRegistre 
        public ElementRegistre AddElementRegistre(String nce, String desc)
        {
            //creation d'un nouvel element Registre avec le param saisie
            ElementRegistre newElement = new ElementRegistre()
            {
                NomClasseExecutable = nce,
                Description = desc
            };
            //ajout du nouvel ElementRegistre au Registre
            context.Registre.Add(newElement);
            //sauvegarde l'ElementRegistre dans la bd
            context.SaveChanges();
            return newElement;
        }

        //Fonction de supression d'un ElementRegistre
        public Boolean RemoveElementRegistre(int id)
        {
            //recherche de l'ElementRegistre
            ElementRegistre e = context.Registre.Find(id);
            //si l'ElementRegistre n'existe pas
            if (e is null)
            {
                return false;
            }
            else  //sinon
            {
                //supression de l'ElementRegistre du registre
                context.Registre.Remove(e);
                //sauvegarde de ce changement dans la bd
                context.SaveChanges();
                return true;
            }
        }

        //fonction de modification d'un ElementRegistre
        public Boolean ModifyElementRegistre(int id, String nce, String desc)
        {
            //recherche de l'ElementRegistre
            ElementRegistre e = context.Registre.Find(id);
            //si l'ElementRegistre n'existe pas
            if (e is null)
            {
                return false;
            }
            else //sinon
            {
                //si un nomClasseExecutable est saisie
                if(nce!="")
                    e.NomClasseExecutable = nce;
                //si une description est saisie
                if(desc!="")
                    e.Description = desc;
                //modification de l'Elementregistre
                context.Attach(e).State = EntityState.Modified;
                //sauvegarde de ce changement dans la bd
                context.SaveChanges();
                return true;
            }
        }

        public ElementRegistre GetElementRegistre(int id)
        {
            return context.Registre.Find(id);
        }
        public async Task<List<ElementRegistre>> GetElementRegistres()
        {
            return await context.Registre.ToListAsync();
        }
    }
}