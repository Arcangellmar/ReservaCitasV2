namespace ReservaCitasV2.Data
{
    public class Cita
    {
        public int Id { get; set; }
        public int IdDoctor { get; set; }
        public Doctor Doctor { get; set; } = new();
        public int IdPaciente { get; set; }
        //public Paciente Paciente { get; set; } = new();
        public int IdDia { get; set; }
        public int IdMes { get; set; }
        public int IdHora { get; set; }
        public string Comentario { get; set; } = string.Empty;
    }
}
