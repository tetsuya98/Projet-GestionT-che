using System;
using System.ComponentModel.DataAnnotations;

namespace ProjetGestionTaches.Models
{
    class ElementRegistre
    {
        public int ID { get; set; }
        [Required]
        public String NomClasseExecutable { get; set; }
        public String Description { get; set; }
        public override string ToString()
        {
            return ID + " : " + NomClasseExecutable + " ( " + Description + " )";
        }
    }
}
