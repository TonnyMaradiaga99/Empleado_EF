using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace empleadovac.Models
{
    public class cargo
    {
        [Key]
        public Guid cargoid {get; set;}

        [ForeignKey("nombre")]
        public string nombre {get;set;}

    }
}