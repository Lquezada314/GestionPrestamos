using GestionPrestamos.Models;
using GestionPrestamos.Components;
using GestionPrestamos.DAL;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GestionPrestamos.Services
{
    public class PrestamosService(IDbContextFactory<Contexto> DbFactory)
    {
        private async Task<bool> Insertar(Prestamos prestamo)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.Prestamos.Add(prestamo);
            return await contexto.SaveChangesAsync() > 0;
        }

        private async Task<bool> Existe(int prestamoId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Prestamos
                .AnyAsync(p => p.PrestamosId == prestamoId);
        }

        private async Task<bool> Modificar(Prestamos prestamo)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.Update(prestamo);
            return await contexto
                .SaveChangesAsync() > 0;
        }

        public async Task<Prestamos?> Buscar(int prestamoId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Prestamos
                .FirstOrDefaultAsync(p => p.PrestamosId == prestamoId);
        }
    }
}
