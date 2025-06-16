using Api.CompliCheck.ViewModels;

namespace Api.CompliCheck.Services
{
    public interface INormaService
    {
        Task<IEnumerable<NormaExibicaoDto>> ListarAsync(int pageNumber, int pageSize);
        Task<NormaExibicaoDto> BuscarPorIdAsync(int id);
        Task<NormaExibicaoDto> CadastrarAsync(NormaCadastroDto dto);
        Task<NormaExibicaoDto> AtualizarAsync(int id, NormaCadastroDto dto);
        Task<bool> DeletarAsync(int id);
    }
}
