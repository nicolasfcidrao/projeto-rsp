using System;
using ProjetoRSP.Shared.Enum;

namespace ProjectRSP.Shared.Requests
{
    public class CreatePessoaRequest
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public DateTimeOffset DataNascimento { get; set; }
        public string Celular { get; set; }
        public string Senha { get; set; }
        public string ContatoEmergencia { get; set; }
        public TipoSanguineo TipoSanguineo { get; set; }
        public Sexo Sexo { get; set; }
    }
}