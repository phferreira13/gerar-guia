using GerarGuia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerarGuia.ApiClient.Interface
{
    public interface IGuiaService
    {
        void Gerar(Guia<Object> guia);
    }
}
