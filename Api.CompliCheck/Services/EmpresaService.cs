using Api.CompliCheck.Models;
using Api.CompliCheck.Repositories;
using Api.CompliCheck.ViewModels;

namespace Api.CompliCheck.Services
{
    public class EmpresaService : IEmpresaService
    {
        private readonly IEmpresaRepository _repository;

        public EmpresaService(IEmpresaRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<EmpresaExibicaoDto>> ListarAsync(int pageNumber, int pageSize)
        {
            var empresas = await _repository.ListarAsync(pageNumber, pageSize);
            return empresas.Select(e => new EmpresaExibicaoDto(e));
        }

        public async Task<EmpresaExibicaoDto> BuscarPorIdAsync(int id)
        {
            var empresa = await _repository.BuscarPorIdAsync(id);
            return empresa != null ? new EmpresaExibicaoDto(empresa) : null;
        }

        public async Task<EmpresaExibicaoDto> CadastrarAsync(EmpresaCadastroDto dto)
        {
            var novaEmpresa = new Empresa
            {
                Nome = dto.Nome,
                Cnpj = dto.Cnpj,
                Setor = dto.Setor
            };
            var empresa = await _repository.AdicionarAsync(novaEmpresa);
            return new EmpresaExibicaoDto(empresa);
        }

        public async Task<EmpresaExibicaoDto> AtualizarAsync(int id, EmpresaCadastroDto dto)
        {
            var empresa = await _repository.BuscarPorIdAsync(id);
            if (empresa == null) return null;

            empresa.Nome = dto.Nome;
            empresa.Cnpj = dto.Cnpj;
            empresa.Setor = dto.Setor;

            var atualizada = await _repository.AtualizarAsync(empresa);
            return new EmpresaExibicaoDto(atualizada);
        }

        public async Task<bool> DeletarAsync(int id)
        {
            return await _repository.RemoverAsync(id);
        }
    }
}
