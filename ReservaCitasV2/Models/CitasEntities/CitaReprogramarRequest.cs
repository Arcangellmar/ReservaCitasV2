namespace ReservaCitasV2.Models.CitasEntities
{
    public class CitaReprogramarRequest
    {
        public int IdCita { get; set; }
        public string? Fecha { get; set; }
        public string? Hora { get; set; }
    }
}
