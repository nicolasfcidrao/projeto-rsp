namespace ProjetoRSP.Models
{
    public class PacienteAlergia
    {
        public Paciente Paciente { get; set; }
        public Alergia Alergia { get; set; }
        public int PacienteId { get; set; }
        public int AlergiaId { get; set; }

        public PacienteAlergia(int pacienteId, int alergiaId)
        {
            PacienteId = pacienteId;
            AlergiaId = alergiaId;
        }
    }
}
