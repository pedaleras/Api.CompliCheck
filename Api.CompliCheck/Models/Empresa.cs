namespace Api.CompliCheck.Models
{
    public class Empresa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public string Setor { get; set; }

        public ICollection<Norma> Normas { get; set; }
    }
}
