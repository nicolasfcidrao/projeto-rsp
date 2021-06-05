﻿using ProjectRSP.Models;
using ProjetoRSP.Shared.Enum;
using System;
using System.Collections.Generic;
using System.Linq;

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
        public string ContatoEmergencia { get; set; }
        public List<PessoaRole> PessoaRoles { get; set; } = new List<PessoaRole>();
        public TipoSanguineo TipoSanguineo { get; set; }
        public Sexo Sexo { get; set; }

        public Pessoa() { }

        public Pessoa(string cpf, string rg, string nome, string email, DateTimeOffset dataNascimento, string celular, string senha, string contatoEmergencia, TipoSanguineo tipoSanguineo, Sexo sexo)
        {
            Cpf = cpf;
            Rg = rg;
            Nome = nome;
            Email = email;
            DataNascimento = dataNascimento;
            Celular = celular;
            Senha = senha;
            ContatoEmergencia = contatoEmergencia;
            TipoSanguineo = tipoSanguineo;
            Sexo = sexo;
        }
        public void AddRolesIds(IEnumerable<int> roleIds)
            => PessoaRoles.AddRange(roleIds.Select(roleId => new PessoaRole(Id, roleId)));
    }
}
