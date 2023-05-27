using System;
using empleadovac.Models;

namespace empleadovac.Service
{
    public class empleadoService : IempleadoService
    {
        context context;
        public empleadoService(context _context)
        {
            context = _context;
        }

        //CRUD
        public async Task CreateAsync(empleado newempleado)
        {
            newempleado.empleadoid = Guid.NewGuid();
            await context.AddAsync<empleado>(newempleado);
            await context.SaveChangesAsync();
        }

        public IEnumerable<empleado> Get()
        {
            return context.empleado;
        }

        public async Task Update(Guid id, empleado updempleado)
        {
            var empleado = context.empleado.Find(id);
            if (empleado != null)
            {
                empleado.empleadoid = updempleado.empleadoid;
                empleado.nombre = updempleado.nombre;
                empleado.fechaingreso = updempleado.fechaingreso;
                empleado.cargoid = updempleado.cargoid;
                empleado.disponible = updempleado.disponible;
                context.Update(empleado);
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

public interface IempleadoService
{
    Task CreateAsync(empleado newempleado);
    IEnumerable<empleado> Get();
    Task Update(Guid id, empleado updempleado);
    Task Delete(Guid id);
}