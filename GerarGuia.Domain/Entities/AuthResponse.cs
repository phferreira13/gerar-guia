using GerarGuia.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerarGuia.Domain.Entities
{
    public class AuthDadosUsuario
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Empresa { get; set; }
        public string Cnpj { get; set; }
    }
    public class AuthDados
    {
        public bool Autenticado { get; set; }
        public string Criacao { get; set; }
        public string Expiracao { get; set; }
        public string Token { get; set; }
        public string Messagem { get; set; }
        public AuthDadosUsuario Usuario { get; set; }
    }
    public class AuthResponse: IAuthResult
    {
        public bool sucesso { get; set; }
        public AuthDados Dados { get; set; }
        public string Erros { get; set; }
        public string AuthKey { get => Dados.Token; }
        public string AuthType { get => "Bearer"; }
    }
}
