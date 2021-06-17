using ProjetoRSP.Shared.Enum;
using System;

namespace ProjetoRSP.Shared.ViewModels
{
    public class PacienteViewModel
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
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Cep { get; set; }
        public string NomeDaMae { get; set; }
        public string NomeDoPai { get; set; }
        public bool InfectadoCovid { get; set; }
        public int QuantasVezesInfectado { get; set; }
        public Sexo Sexo { get; set; }

    }
}
