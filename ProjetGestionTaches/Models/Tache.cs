using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Threading;

namespace ProjetGestionTaches.Models
{
    class Tache
    {
        [Key]
        public int PID { get; set; }
        [Required]
        public Utilisateur Proprietaire { get; set; }
        [Required]

        private static int lastPID ;

        static InterfaceExe ie;

        public ElementRegistre Entry { get; set; }

        public Tache(Utilisateur p_proprietaire, ElementRegistre p_entry)
        {
            this.PID = lastPID + 1;
            lastPID++;
            Proprietaire = p_proprietaire;
            Entry = p_entry;
        }

        public Tache()
        {
            this.PID = lastPID + 1;
            lastPID++;
            this.Proprietaire = null;
            this.Entry = null;
        }

        public override string ToString()
        {
            return PID + " : " + Proprietaire.UserName + " ( " + Entry.NomClasseExecutable + " )";
        }

        public void Start(String p_nom)
        {
            Type[] lesTypes = Assembly.GetCallingAssembly().GetTypes();

            foreach (Type t in lesTypes)
            {
                
                if (t.Name == p_nom)
                {
                    Console.WriteLine(t.Name);
                    Console.WriteLine(p_nom);
                    ie = (InterfaceExe)Activator.CreateInstance(t);
                    ie.PID = this.PID;
                    Console.WriteLine(ie.PID);
                    Thread th = new Thread(new ThreadStart(ThreadExe));
                    th.Start();
                }
            }
        }

        public static void ThreadExe()
        {
            Console.WriteLine("thread...");
            ie.Exe();
            Thread.Sleep(0);
        }
    }
}
