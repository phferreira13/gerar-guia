using GerarGuia.Domain.Shared.Enum;
using System.Text.Json;

namespace GerarGuia.Domain.Entities
{
    public class Guia<T>
    {
        public ETipoGuia TipoGuia { get; set; }
        public string? Id { get; set; }
        public int? GuiaID { get; set; }
        public T? Dados { get; set; }

        public Guia()
        {
        }

        public Guia(ETipoGuia tipoGuia, string? id, int? guiaID, T? dados)
        {
            TipoGuia = tipoGuia;
            Id = id;
            GuiaID = guiaID;
            Dados = dados;
        }

        public string ToJSON()
        {
            return JsonSerializer.Serialize(this);
        }
        public O Cast<O>()
        {
            var res = ToJSON();
            return JsonSerializer.Deserialize<O>(res);
        }
    }
}
