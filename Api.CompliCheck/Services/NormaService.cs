
using Api.CompliCheck.Models;
using Api.CompliCheck.Repositories;
using Api.CompliCheck.ViewModels;

namespace Api.CompliCheck.Services
{
    public class NormaService : INormaService
    {
        private readonly INormaRepository _repository;
        private readonly IEmpresaRepository _empresaRepository;

        public NormaService(INormaRepository repository, IEmpresaRepository empresaRepository)
        {
            _repository = repository;
            _empresaRepository = empresaRepository;
        }

        public async Task<IEnumerable<NormaExibicaoDto>> ListarAsync(int pageNumber, int pageSize)
        {
            var normas = await _repository.ListarAsync(pageNumber, pageSize);
            return normas.Select(n => new NormaExibicaoDto(n));
        }

        public async Task<NormaExibicaoDto> BuscarPorIdAsync(int id)
        {
            var norma = await _repository.BuscarPorIdAsync(id);
            return norma != null ? new NormaExibicaoDto(norma) : null;
        }

        public async Task<NormaExibicaoDto> CadastrarAsync(NormaCadastroDto dto)
        {
            var empresa = await _empresaRepository.BuscarPorIdAsync(dto.EmpresaId);
            if (empresa == null) return null;

            var novaNorma = new Norma
            {
                Descricao = dto.Descricao,
                Categoria = dto.Categoria,
                DataLimite = dto.DataLimite,
                Empresa = empresa
            };

            var norma = await _repository.AdicionarAsync(novaNorma);
            return new NormaExibicaoDto(norma);
        }

        public async Task<NormaExibicaoDto> AtualizarAsync(int id, NormaCadastroDto dto)
        {
            var norma = await _repository.BuscarPorIdAsync(id);
            if (norma == null) return null;

            norma.Descricao = dto.Descricao;
            norma.Categoria = dto.Categoria;
            norma.DataLimite = dto.DataLimite;

            var empresa = await _empresaRepository.BuscarPorIdAsync(dto.EmpresaId);
            if (empresa != null)
                norma.Empresa = empresa;

            var atualizada = await _repository.AtualizarAsync(norma);
            return new NormaExibicaoDto(atualizada);
        }

        public async Task<bool> DeletarAsync(int id)
        {
            return await _repository.RemoverAsync(id);
        }
    }
}
