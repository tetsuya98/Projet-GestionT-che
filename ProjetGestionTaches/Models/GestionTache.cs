using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetGestionTaches.Models
{
    class GestionTache
    {
        Dictionary<int, Tache> dict = null;
        public GestionTache()
        {
            dict = new Dictionary<int, Tache>();
        }
        public Tache AjouterTache(Utilisateur p, ElementRegistre e)
        {
            Tache tache = new Tache(p, e);
            dict.Add(tache.PID, tache);
            tache.Start(e.NomClasseExecutable);

            return tache;
        }

        public Tache GetTache(int PID)
        {
            Tache tache = null;
            for (int i = 0; i < dict.Count; i++)
            {
                tache = dict[dict.Keys.ElementAt(i)];
            }
            return tache;
        }

        public int NbTaches()
        {
            return dict.Count;
        }
    }
}
