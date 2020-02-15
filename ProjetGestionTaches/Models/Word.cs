using System;
using System.Text;

namespace ProjetGestionTaches.Models
{
    class Word : InterfaceExe
    {
        public int PID { get; set; }
        public int Progression { get; set; }
        public Word()
        {
        }

        public void Exe()
        {
            Console.WriteLine("winwordexe");
            WinWordExe();
        }

        public void WinWordExe()
        {
            Console.WriteLine("+++++++++++ Démarrage de Word dans le processus " + PID);
            Progression = 0;
            while (Progression < 50)
            {
                Progression++;
                Console.WriteLine("Le processus Word " + PID + " a le contrôle. Progression = " +
                    Progression);

            }
            Console.WriteLine("*********** Fin du processus Word " + PID);
        }
    }

}