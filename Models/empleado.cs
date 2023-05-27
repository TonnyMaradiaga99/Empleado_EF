using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace empleadovac.Models
{
    public class empleado
    {
        [Key]
        public Guid empleadoid {get; set;}
        public string nombre {get;set;}

        public string fechaingreso {get;set;}

        [ForeignKey("cargoid")]
        public string cargoid {get;set;}

        public bool disponible {get;set;}

        public string disponibletex => disponible ? "Activo" : "Inactivo";
    

    }
}