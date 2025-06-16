using Api.CompliCheck.ViewModels;

namespace Api.CompliCheck.Services
{

    public interface IEmpresaService
    {
        Task<IEnumerable<EmpresaExibicaoDto>> ListarAsync(int pageNumber, int pageSize);
        Task<EmpresaExibicaoDto> BuscarPorIdAsync(int id);
        Task<EmpresaExibicaoDto> CadastrarAsync(EmpresaCadastroDto dto);
        Task<EmpresaExibicaoDto> AtualizarAsync(int id, EmpresaCadastroDto dto);
        Task<bool> DeletarAsync(int id);
    }

}
