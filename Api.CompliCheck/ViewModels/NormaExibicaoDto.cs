using Api.CompliCheck.Models;

namespace Api.CompliCheck.ViewModels
{
    public class NormaExibicaoDto
    {
        public NormaExibicaoDto(Norma n)
        {
            this.Id = n.Id;
            this.Descricao = n.Descricao;
            this.Categoria = n.Categoria;
            this.DataLimite = n.DataLimite;
            this.EmpresaNome = n.Empresa.Nome;
        }

        public int Id { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public string Categoria { get; set; } = string.Empty;
        public DateTime DataLimite { get; set; }
        public string EmpresaNome { get; set; } = string.Empty;
    }
}