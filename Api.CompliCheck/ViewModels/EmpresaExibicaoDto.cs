using Api.CompliCheck.Models;

namespace Api.CompliCheck.ViewModels
{
    public class EmpresaExibicaoDto
    {
        public EmpresaExibicaoDto(Empresa e)
        {
            this.Id = e.Id;
            this.Nome = e.Nome;
            this.Cnpj = e.Cnpj;
        }

        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Cnpj { get; set; } = string.Empty;
    }
}