using System;

namespace ProjetoRSP.Models
{
    public class Consulta : Entidade   
    {
        public DateTimeOffset DataConsulta { get; set; }
        public int PacienteId { get; set; }
        public Paciente Paciente { get; set; }
        public int ProfissionalId { get; set; }
        public Profissional Profissional { get; set; }

        public Consulta() { }

        public Consulta(DateTimeOffset dataConsulta, int pacienteId, int profissionalId)
        {
            DataConsulta = dataConsulta;
            PacienteId = pacienteId;
            ProfissionalId = profissionalId;
        }
    }
}
