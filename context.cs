using Microsoft.EntityFrameworkCore;
using empleadovac.Models;

namespace empleadovac
{
    public class context:DbContext
    {
        public DbSet<cargo> cargo {get; set; }

        public DbSet<codigotrabajo> codigotrabajo {get; set; }

        public DbSet<empleado> empleado {get; set; }

        public DbSet<vacaciones> vacaciones {get; set; }
        

        public context(DbContextOptions<context> options) : base(options){}

    }
}