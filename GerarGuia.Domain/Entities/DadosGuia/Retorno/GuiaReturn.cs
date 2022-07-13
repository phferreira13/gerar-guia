using GerarGuia.Domain.Shared.Enum;

namespace GerarGuia.Domain.Entities.DadosGuia.Retorno
{
    public class GuiaReturnDados
    {
        public string Id { get; set; }
        public int StatusProcessamento { get; set; }
        public string StatusProcessamentoDescricao { get; set; }
        public ETipoGuia TipoGuia { get; set; }
        public string TipoGuiaDescricao { get; set; }
        public bool ErroProcessamento { get; set; }
        public string MensagemErro { get; set; }
        public string UF { get; set; }

    }
    public class GuiaReturn
    {
        public bool Sucesso { get; set; }
        public List<string> Erros { get; set; }
        public GuiaReturnDados Dados { get; set; }
    }
}
