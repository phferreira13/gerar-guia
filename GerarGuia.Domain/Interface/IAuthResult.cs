using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerarGuia.Domain.Interface
{
    public interface IAuthResult
    {
        public string AuthKey { get; }
        public string AuthType { get; }
    }
}
