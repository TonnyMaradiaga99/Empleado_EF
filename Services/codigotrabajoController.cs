using System;
using empleadovac.Models;

namespace empleadovac.Service
{
    public class codigotrabajoService : IcodigotrabajoService
    {
        context context;
        public codigotrabajoService(context _context)
        {
            context = _context;
        }

        //CRUD
        public async Task CreateAsync(codigotrabajo newcodigotrabajo)
        {
            newcodigotrabajo.codigotrabajoid = Guid.NewGuid();
            await context.AddAsync<codigotrabajo>(newcodigotrabajo);
            await context.SaveChangesAsync();
        }

        public IEnumerable<codigotrabajo> Get()
        {
            return context.codigotrabajo;
        }

        public async Task Update(Guid id, codigotrabajo updcodigotrabajo)
        {
            var codigotrabajo = context.codigotrabajo.Find(id);
            if (codigotrabajo != null)
            {
                codigotrabajo.codigotrabajoid = updcodigotrabajo.codigotrabajoid;
                codigotrabajo.antiguedad = updcodigotrabajo.antiguedad;
                codigotrabajo.diasotorgados = updcodigotrabajo.diasotorgados;
                codigotrabajo.vigente = updcodigotrabajo.vigente;
                context.Update(codigotrabajo);
                await context.SaveChangesAsync();
            }
        }

        public async Task Delete(Guid id)
        {
            var codigotrabajo = context.codigotrabajo.Find(id);
            if (codigotrabajo != null)
            {
                context.Remove(codigotrabajo);
                await context.SaveChangesAsync();
            }
        }
    }
}

public interface IcodigotrabajoService
{
    Task CreateAsync(codigotrabajo newcodigotrabajo);
    IEnumerable<codigotrabajo> Get();
    Task Update(Guid id, codigotrabajo updcodigotrabajo);
    Task Delete(Guid id);
}