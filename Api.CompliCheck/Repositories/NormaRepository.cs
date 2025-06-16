using Api.CompliCheck.Data;
using Api.CompliCheck.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Api.CompliCheck.Repositories
{
    public class NormaRepository : INormaRepository
    {
        private readonly DatabaseContext _context;

        public NormaRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<List<Norma>> ListarAsync(int pagina, int tamanhoPagina)
        {
            return await _context.Normas
                .Include(n => n.Empresa)
                .Skip((pagina - 1) * tamanhoPagina)
                .Take(tamanhoPagina)
                .ToListAsync();
        }

        public async Task<Norma> BuscarPorIdAsync(int id)
        {
            return await _context.Normas
                .Include(n => n.Empresa)
                .FirstOrDefaultAsync(n => n.Id == id);
        }

        public async Task<Norma> AdicionarAsync(Norma norma)
        {
            _context.Normas.Add(norma);
            await _context.SaveChangesAsync();
            return norma;
        }

        public async Task<Norma> AtualizarAsync(Norma norma)
        {
            _context.Normas.Update(norma);
            await _context.SaveChangesAsync();
            return norma;
        }

        public async Task<bool> RemoverAsync(int id)
        {
            var norma = await _context.Normas.FindAsync(id);
            if (norma == null) return false;

            _context.Normas.Remove(norma);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
