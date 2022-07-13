
namespace GerarGuia.Domain.Entities.DadosGuia.Envio
{
    public class DarfEnvio
    {
        public string? CNPJ { get; set; }
        public DateTime PeriodoApuracao { get; set; }
        public double ValorPrincipal { get; set; }
        public string? CodigoReceita { get; set; }
        public string? Observacao { get; set; }
    }
}
