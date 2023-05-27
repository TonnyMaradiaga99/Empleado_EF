using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace empleadovac.Models
{
    public class codigotrabajo
    {
        [Key]
        public Guid codigotrabajoid {get; set;}
        public int antiguedad {get;set;}

        public int diasotorgados {get;set;}

        public bool vigente {get;set;}

        public string vigentetex => vigente ? "Activo" : "Inactivo";
    

    }
}