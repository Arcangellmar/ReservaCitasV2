using ReservaCitasV2.Data;

namespace ReservaCitasV2.Models
{
    public class HomeModel
    {
        public Paciente? Usuario { get; set; }
        public List<Especialidad> lstEspecialidad { get; set; } = new();
        public List<Doctor> lstDoctor { get; set; } = new();
        public List<Hora> lstHora { get; set; } = new();
        public List<Cita> lstCita { get; set; } = new();
        public List<Cita> lstCitaProgramada { get; set; } = new();

        public List<Local> lstLocal { get; set; } = new();
    }
}
