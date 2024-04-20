using Microsoft.AspNetCore.Mvc;
using ReservaCitasV2.DAO;
using ReservaCitasV2.Data;
using ReservaCitasV2.Models;
using ReservaCitasV2.Models.CitasEntities;
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
            int IdUsuario = int.Parse(Request.Cookies["IdUsuario"]);

            model.Usuario = loginDao.ObtenerUsuario(IdUsuario);

            model.lstDoctor = loginDao.DoctoresListar();

            model.lstEspecialidad = loginDao.EspecialidadListar();

            model.lstLocal = loginDao.LocalListar();

            model.lstHora = [
                new Hora { Id = 1, Name = "07:00" },
                new Hora { Id = 2, Name = "07:30" },
                new Hora { Id = 2, Name = "08:00" },
                new Hora { Id = 2, Name = "08:30" },
                new Hora { Id = 2, Name = "09:00" },
                new Hora { Id = 2, Name = "09:30" },
                new Hora { Id = 2, Name = "10:00" },
            ];

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
        public bool LogOut()
        {
            Response.Cookies.Delete("IdUsuario");

            return true;
        }

        [HttpGet]
        public Paciente ObtenerUsuario([FromQuery] int? IdUsuario)
        {
            return loginDao.ObtenerUsuario(IdUsuario);
        }

        [HttpPost]
        public GeneralResponse CitaRegistrar([FromBody] CitaCrearRequest request)
        {

            GeneralResponse response = new();

            try
            {
                var sucess = loginDao.CitaRegistrar(request);

                if (sucess)
                {
                    response.Estado = true;
                    response.Mensaje = "Proceso Exitoso";
                }
                else
                {
                    response.Estado = false;
                    response.Mensaje = "Sucedio un error al crear la cita";
                }

            }
            catch(Exception ex)
            {
                response.Estado = false;
                response.Mensaje = ex.Message;
            }

            return response;
        }

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
