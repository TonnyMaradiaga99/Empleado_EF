using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace empleadovac.Models
{
    public class vacaciones
    {
        [Key]
        public Guid vacacionesid {get; set;}

        public string fecha {get;set;}

        [ForeignKey("empleadoid")]
        public string empleadoid {get;set;}

        

    }
}