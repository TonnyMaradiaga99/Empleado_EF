using System;
using empleadovac.Models;

namespace empleadovac.Service
{
    public class vacacionesService : IvacacionesService
    {
        context context;
        public vacacionesService(context _context)
        {
            context = _context;
        }

        //CRUD
        public async Task CreateAsync(vacaciones newvacaciones)
        {
            newvacaciones.vacacionesid = Guid.NewGuid();
            await context.AddAsync<vacaciones>(newvacaciones);
            await context.SaveChangesAsync();
        }

        public IEnumerable<vacaciones> Get()
        {
            return context.vacaciones;
        }

        public async Task Update(Guid id, vacaciones updvacaciones)
        {
            var vacaciones = context.vacaciones.Find(id);
            if (vacaciones != null)
            {
                vacaciones.vacacionesid = updvacaciones.vacacionesid;
                vacaciones.fecha = updvacaciones.fecha;
                vacaciones.empleadoid = updvacaciones.empleadoid;
                context.Update(vacaciones);
                await context.SaveChangesAsync();
            }
        }

        public async Task Delete(Guid id)
        {
            var vacaciones = context.vacaciones.Find(id);
            if (vacaciones != null)
            {
                context.Remove(vacaciones);
                await context.SaveChangesAsync();
            }
        }
    }
}

public interface IvacacionesService
{
    Task CreateAsync(vacaciones newvacaciones);
    IEnumerable<vacaciones> Get();
    Task Update(Guid id, vacaciones updvacaciones);
    Task Delete(Guid id);
}