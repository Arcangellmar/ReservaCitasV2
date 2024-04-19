namespace ReservaCitasV2.Data
{
    public class Doctor
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int IdEspecialidad { get; set; }
        public string? NombreEspecialidad { get; set; }
        //public Especialidad Especialidad { get; set; } = new Especialidad();
    }
}
