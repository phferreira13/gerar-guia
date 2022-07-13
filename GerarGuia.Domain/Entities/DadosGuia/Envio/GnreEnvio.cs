
namespace GerarGuia.Domain.Entities.DadosGuia.Envio
{
    public class GnreEnvio
    {
        public string? UfFavorecida { get; set; }
        public string? CodigoReceita { get; set; }
        public string? CodigoDetalhamentoReceita { get; set; }
        public int? CodigoProduto { get; set; }
        public EmitenteGNRE? Emitente { get; set; }
        public string? TipoPeriodoReferencia { get; set; }
        public int PeriodoReferenciaMes { get; set; }
        public int PeriodoReferenciaAno { get; set; }
        public DateTime? DataVencimento { get; set; }
        public DateTime? DataPagamento { get; set; }
        public double Valor { get; set; }
        public int Parcela { get; set; }
        public string? IdentificadorGuia { get; set; }
        public bool ErroProcessamento { get; set; }
    }
}
