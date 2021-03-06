namespace ProjetoRSP.Models
{
    public class Alergia : Entidade
    {
        public string Nome { get; set; }

        public Alergia() { }

        public Alergia(string nome)
        {
            Nome = nome;
        }
    }
}
