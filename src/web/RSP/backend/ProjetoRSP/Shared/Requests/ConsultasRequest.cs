
using ProjetoRSP.Models;
using System;

namespace ProjetoRSP.Shared.Requests
{
    public class ConsultasRequest
    {
        public DateTimeOffset DataConsulta { get; set; }
        public int PacienteId { get; set; }
        public int ProfissionalId { get; set; }
    }
}
