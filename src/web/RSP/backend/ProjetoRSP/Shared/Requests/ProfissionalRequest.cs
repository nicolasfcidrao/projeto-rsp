using System;

namespace ProjetoRSP.Shared.Requests
{
    public class ProfissionalRequest
    {
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTimeOffset DataNascimento { get; set; }
        public string Celular { get; set; }
        public string Senha { get; set; }
        public string CodProfissional { get; set; }
        public string Especialidade { get; set; }
        public string RazaoSocial { get; set; }
        public string Cnpj { get; set; }

    }
}
