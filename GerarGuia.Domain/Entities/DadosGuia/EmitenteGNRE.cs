namespace GerarGuia.Domain.Entities.DadosGuia
{
    public class EmitenteGNRE
    {
        public int TipoIdentificacao { get; set; }
        public string? Identificacao { get; set; }
        public string? RazaoSocial { get; set; }
        public string? Endereco { get; set; }
        public string? CodigoIBGEMunicipio { get; set; }
        public string? Uf { get; set; }
        public string? Cep { get; set; }
        public string? Telefone { get; set; }
    }
}
