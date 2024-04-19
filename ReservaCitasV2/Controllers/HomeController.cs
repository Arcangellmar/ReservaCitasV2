using Microsoft.AspNetCore.Mvc;
using ReservaCitasV2.DAO;
using ReservaCitasV2.Data;
using ReservaCitasV2.Models;
using ReservaCitasV2.Models.Login;
using System.Diagnostics;

namespace ReservaCitasV2.Controllers
{
    public class HomeController : Controller
    {
        HomeModel model = new();

        readonly DaoClass loginDao = new();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Home()
        {
            model.Usuario = ObtenerUsuario(int.Parse(Request.Cookies["IdUsuario"]));

            model.lstDoctor = loginDao.DoctoresListar();

            model.lstEspecialidad = loginDao.EspecialidadListar();


            AddHora(1, "07:00");
            AddHora(2, "07:30");
            AddHora(3, "08:00");
            AddHora(4, "08:30");
            AddHora(5, "09:00");
            AddHora(6, "09:30");
            AddHora(7, "10:00");

            //var lstEspecialidades = new List<string>()
            //{
            //};
            //for (int i = 0; i < lstEspecialidades.Count(); i++)
            //{
            //    AddEspecialidad(i, lstEspecialidades[i], new List<int> { 1, 2, 3, 4, 5 }, new List<int> { 1, 2, 3, 4, 5, 6, 7 });
            ////}
            //AddDoctor(1, "", 0);
            //AddDoctor(2, "", 1);
            //AddDoctor(3, "", 1);
            //AddDoctor(4, "", 1);
            //AddDoctor(5, "", 2);
            //AddDoctor(6, "", 3);
            AddCita(1, 2, 3, 9, 4, "ATENCION AMBULATORIA");
            AddCita(2, 1, 4, 9, 4, "ATENCION AMBULATORIA");
            AddCita(3, 2, 11, 9, 4, "ATENCION AMBULATORIA");
            AddCita(4, 3, 13, 9, 4, "ATENCION AMBULATORIA");
            AddCita(5, 1, 16, 9, 4, "ATENCION AMBULATORIA");
            AddCitaProgramada(1, 1, 28, 10, 1, "");
            AddCitaProgramada(2, 3, 30, 10, 2, "");

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public LoginResponse Login([FromBody] LoginRequest request)
        {

            var response = loginDao.Login(request.Usuario, request.Pass);

            if (response.Estado == true)
            {
                Response.Cookies.Append("IdUsuario", response.IdUsuario.ToString());
            }

            return response;
        }

        [HttpGet]
        public Paciente ObtenerUsuario([FromQuery] int? IdUsuario)
        {
            return loginDao.ObtenerUsuario(IdUsuario);
        }

        private void AddHora(int id, string name)
        {
            var e = new Hora { Id = id, Name = name };
            model.lstHora.Add(e);
        }
        //public Paciente Paciente { get; set; } = new Paciente()
        //{
        //    Id = 1,
        //    Name = "Gino Monrroy",
        //    Edad = 26,
        //    Sexo = 1,
        //    Altura = 1.82,
        //    Peso = 81.5,
        //    Seguro = 0,
        //};
        //private void AddDoctor(int id, string name, int IdEspecialidad)
        //{
        //    var esp = model.lstEspecialidad.FirstOrDefault(u => u.Id == IdEspecialidad) ?? throw new Exception("Sin Especialidad");
        //    var e = new Doctor()
        //    {
        //        Id = id,
        //        Name = name,
        //        IdEspecialidad = IdEspecialidad,
        //        Especialidad = esp,
        //    };
        //    model.lstDoctor.Add(e);
        //}
        //private void AddEspecialidad(int id, string name, List<int> dias, List<int> horas)
        //{
        //    var e = new Especialidad()
        //    {
        //        Id = id,
        //        Name = name,
        //        Dias = dias,
        //        Horas = horas
        //    };
        //    model.lstEspecialidad.Add(e);
        //}
        private void AddCita(int id, int idDoctor, int idDia, int idMes, int idHora, string comentario)
        {
            var doc = model.lstDoctor.FirstOrDefault(u => u.Id == idDoctor) ?? throw new Exception("Sin Médico");
            var e = new Cita()
            {
                Id = id,
                IdDoctor = idDoctor,
                Doctor = doc,
                IdDia = idDia,
                IdMes = idMes,
                IdHora = idHora,
                Comentario = comentario,
            };
            model.lstCita.Add(e);
        }
        private void AddCitaProgramada(int id, int idDoctor, int idDia, int idMes, int idHora, string comentario)
        {
            var doc = model.lstDoctor.FirstOrDefault(u => u.Id == idDoctor) ?? throw new Exception("Sin Médico");
            var e = new Cita()
            {
                Id = id,
                IdDoctor = idDoctor,
                Doctor = doc,
                IdDia = idDia,
                IdMes = idMes,
                IdHora = idHora,
                Comentario = comentario,
            };
            model.lstCitaProgramada.Add(e);
        }

    }
}
