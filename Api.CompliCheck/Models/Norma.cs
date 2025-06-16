namespace Api.CompliCheck.Models
{
    public class Norma
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Categoria { get; set; }
        public DateTime DataLimite { get; set; }

        public int EmpresaId { get; set; }
        public Empresa Empresa { get; set; }
    }

}
