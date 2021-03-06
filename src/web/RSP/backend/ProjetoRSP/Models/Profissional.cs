namespace ProjetoRSP.Models
{
    public class Profissional : Entidade
    {
        public string CodProfissional { get; set; }
        public string Especialidade { get; set; }
        public string RazaoSocial { get; set; }
        public string Cnpj { get; set; }
        public int PessoaId { get; set; }
        public Pessoa Pessoa { get; set; }

        public Profissional() { }

        public Profissional(string codProfissional, string especialidade, string razaoSocial, string cnpj, int pessoaId)
        {
            CodProfissional = codProfissional;
            Especialidade = especialidade;
            RazaoSocial = razaoSocial;
            Cnpj = cnpj;
            PessoaId = pessoaId;
        }
    }
}
