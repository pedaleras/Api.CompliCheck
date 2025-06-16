namespace Api.CompliCheck.ViewModels
{
    public class NormaCadastroDto
    {
        public string Descricao { get; set; } = string.Empty;
        public string Categoria { get; set; } = string.Empty;
        public DateTime DataLimite { get; set; }
        public int EmpresaId { get; set; }
    }
}