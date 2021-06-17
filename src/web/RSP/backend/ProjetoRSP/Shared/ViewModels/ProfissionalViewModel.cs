using ProjetoRSP.Shared.Enum;
using System;

namespace ProjetoRSP.Shared.ViewModels
{
    public class ProfissionalViewModel
    {
        public int Id { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTimeOffset DataNascimento { get; set; }
        public string Celular { get; set; }
        public string Senha { get; set; }
        public string ContatoEmergencia { get; set; }
        public TipoSanguineo TipoSanguineo { get; set; }
        public string CodProfissional { get; set; }
        public string Especialidade1 { get; set; }
        public string Especialidade2 { get; set; }
        public string RazaoSocial1 { get; set; }
        public string RazaoSocial2 { get; set; }
        public string Cnpj { get; set; }
        public Sexo Sexo { get; set; }

    }
}
