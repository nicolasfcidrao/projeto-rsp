using ProjetoRSP.Models;

namespace ProjectRSP.Models
{
    public class Role : Entidade
    {
        public Role()
        { }
        
        public Role(string name) => Name = name;

        public Role (int id, string name) : this (name)
            => Id = id;

        public string Name { get; set; }
    }
}