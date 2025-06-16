using Api.CompliCheck.Models;

namespace Api.CompliCheck.Repositories
{
    public interface INormaRepository
    {
        Task<List<Norma>> ListarAsync(int pagina, int tamanhoPagina);
        Task<Norma> BuscarPorIdAsync(int id);
        Task<Norma> AdicionarAsync(Norma norma);
        Task<Norma> AtualizarAsync(Norma norma);
        Task<bool> RemoverAsync(int id);
    }
}
