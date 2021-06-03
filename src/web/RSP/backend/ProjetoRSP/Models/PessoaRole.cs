using ProjetoRSP.Models;

namespace ProjectRSP.Models
{
    public class PessoaRole
    {
        public PessoaRole(int pessoaId, int roleId)
        {
            PessoaId = pessoaId;
            RoleId = roleId;
        }

        public int PessoaId { get; set; }
        public Pessoa Pessoa { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}