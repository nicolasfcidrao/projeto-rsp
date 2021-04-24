namespace ProjetoRSP.Models
{
    public class Profissional : Entidade
    {
        public string CodProfissional { get; set; }
        public string Especialidade1 { get; set; }
        public string Especialidade2 { get; set; }
        public string RazaoSocial1 { get; set; }
        public string RazaoSocial2 { get; set; }
        public string Cnpj { get; set; }
        public int PessoaId { get; set; }
        public Pessoa Pessoa { get; set; }

        public Profissional() { }

        public Profissional(string codProfissional, string especialidade1, string especialidade2, string razaoSocial1, string razaoSocial2, string cnpj, int pessoaId)
        {
            CodProfissional = codProfissional;
            Especialidade1 = especialidade1;
            Especialidade2 = especialidade2;
            RazaoSocial1 = razaoSocial1;
            RazaoSocial2 = razaoSocial2;
            Cnpj = cnpj;
            PessoaId = pessoaId;
        }
    }
}
