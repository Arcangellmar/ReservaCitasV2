namespace ReservaCitasV2.Data
{
    public class Cita
    {
        public int Id { get; set; }
        //public Doctor Doctor { get; set; } = new();
        public string? NombreDoctor { get; set; }
        public string? EspecialidadDoctor { get; set; }
        //public int IdDia { get; set; }
        //public int IdMes { get; set; }
        public string? Fecha { get; set; }
        public string? Hora { get; set; }
        //public int IdHora { get; set; }
    }
}
