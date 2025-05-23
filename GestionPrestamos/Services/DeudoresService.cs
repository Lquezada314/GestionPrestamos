using GestionPrestamos.Components;
using GestionPrestamos.Models;
using GestionPrestamos.DAL;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GestionPrestamos.Services
{
    public class DeudoresService(IDbContextFactory<Contexto> DbFactory)
    {
        private async Task<bool> Insertar(Deudores deudor)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.Deudores.Add(deudor);
            return await contexto.SaveChangesAsync() > 0;
        }
        private async Task<bool> Existe(int deudorId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Deudores
                .AnyAsync(d => d.DeudorId == deudorId);
        }
        private async Task<bool> Modificar(Deudores deudor)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.Update(deudor);
            return await contexto
                .SaveChangesAsync() > 0;
        }
        public async Task<Deudores?> Buscar(int deudorId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Deudores
                .FirstOrDefaultAsync(d => d.DeudorId == deudorId);
        }
        public async Task<bool> Eliminar(int deudorId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Deudores
                .AsNoTracking()
                .Where(d => d.DeudorId == deudorId)
                .ExecuteDeleteAsync() > 0;
        }
        public async Task<bool> Guardar(Deudores deudor)
        {
            if (!await Existe(deudor.DeudorId))
            {
                return await Insertar(deudor);
            }
            else
            {
                return await Modificar(deudor);
            }
        }
        public async Task<List<Deudores>> GetList(Expression<Func<Deudores, bool>> criterio)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Deudores
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }
    }
}
