using ProjetoRSP.Models;
using System;

namespace ProjetoRSP.Shared.ViewModels
{
    public class ConsultaViewModel
    {
        public int Id { get; set; }
        public DateTimeOffset DataConsulta { get; set; }
        public int PacienteId { get; set; }
        public string NomePaciente { get; set; }
        public int ProfissionalId { get; set; }
        public string ProfissionalNome { get; set; }
        public string CodProfissional { get; set; }

    }
}
