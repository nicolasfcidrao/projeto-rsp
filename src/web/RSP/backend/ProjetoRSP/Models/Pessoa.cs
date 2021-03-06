using System;

namespace ProjetoRSP.Models
{
    public class Pessoa : Entidade
    {
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTimeOffset DataNascimento { get; set; }
        public string Celular { get; set; }
        public string Senha { get; set; }

        public Pessoa() { }

        public Pessoa(string cpf, string rg, string nome, string email, DateTimeOffset dataNascimento, string celular, string senha)
        {
            Cpf = cpf;
            Rg = rg;
            Nome = nome;
            Email = email;
            DataNascimento = dataNascimento;
            Celular = celular;
            Senha = senha;
        }
    }
}
