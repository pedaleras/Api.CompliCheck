using Api.CompliCheck.Models;

namespace Api.CompliCheck.Repositories
{
    public interface IEmpresaRepository
    {
        Task<List<Empresa>> ListarAsync(int pagina, int tamanhoPagina);
        Task<Empresa> BuscarPorIdAsync(int id);
        Task<Empresa> AdicionarAsync(Empresa empresa);
        Task<Empresa> AtualizarAsync(Empresa empresa);
        Task<bool> RemoverAsync(int id);
    }
}
