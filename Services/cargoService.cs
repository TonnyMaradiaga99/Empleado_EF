using System;
using empleadovac.Models;

namespace empleadovac.Service
{
    public class cargoService : IcargoService
    {
        context context;
        public cargoService(context _context)
        {
            context = _context;
        }

        //CRUD
        public async Task CreateAsync(cargo newcargo)
        {
            newcargo.cargoid = Guid.NewGuid();
            await context.AddAsync<cargo>(newcargo);
            await context.SaveChangesAsync();
        }

        public IEnumerable<cargo> Get()
        {
            return context.cargo;
        }

        public async Task Update(Guid id, cargo updcargo)
        {
            var cargo = context.cargo.Find(id);
            if (cargo != null)
            {
                cargo.cargoid = updcargo.cargoid;
                cargo.nombre = updcargo.nombre;
                context.Update(cargo);
                await context.SaveChangesAsync();
            }
        }

        public async Task Delete(Guid id)
        {
            var cargo = context.cargo.Find(id);
            if (cargo != null)
            {
                context.Remove(cargo);
                await context.SaveChangesAsync();
            }
        }
    }
}

public interface IcargoService
{
    Task CreateAsync(cargo newcargo);
    IEnumerable<cargo> Get();
    Task Update(Guid id, cargo updcargo);
    Task Delete(Guid id);
}