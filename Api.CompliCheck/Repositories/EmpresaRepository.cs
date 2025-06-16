using Api.CompliCheck.Data;
using Api.CompliCheck.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.CompliCheck.Repositories
{
    public class EmpresaRepository : IEmpresaRepository
    {
        private readonly DatabaseContext _context;

        public EmpresaRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<List<Empresa>> ListarAsync(int pagina, int tamanhoPagina)
        {
            return await _context.Empresas
                .Skip((pagina - 1) * tamanhoPagina)
                .Take(tamanhoPagina)
                .ToListAsync();
        }

        public async Task<Empresa> BuscarPorIdAsync(int id)
        {
            return await _context.Empresas.FindAsync(id);
        }

        public async Task<Empresa> AdicionarAsync(Empresa empresa)
        {
            _context.Empresas.Add(empresa);
            await _context.SaveChangesAsync();
            return empresa;
        }

        public async Task<Empresa> AtualizarAsync(Empresa empresa)
        {
            _context.Empresas.Update(empresa);
            await _context.SaveChangesAsync();
            return empresa;
        }

        public async Task<bool> RemoverAsync(int id)
        {
            var empresa = await _context.Empresas.FindAsync(id);
            if (empresa == null) return false;

            _context.Empresas.Remove(empresa);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
