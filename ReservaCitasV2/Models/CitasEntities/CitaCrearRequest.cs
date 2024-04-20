namespace ReservaCitasV2.Models.CitasEntities
{
    public class CitaCrearRequest
    {
        public int? IdDoctor { get; set; }
        public int? IdEspecialidad { get; set; }
        public int? IdPaciente { get; set; }
        public string? Fecha { get; set; }
        public string? Hora { get; set; }
        public int? IdLocal { get; set; }
    }
}
