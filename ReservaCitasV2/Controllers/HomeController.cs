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

        readonly DaoClass loginDao = new();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Home()
        {
            try
            {

                HomeModel model = new();

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

                model.lstCita = loginDao.CitaListar();
                model.lstCitaProgramada = loginDao.CitaListarProgramada();

                return View(model);
            }
            catch
            {
                return RedirectToAction("Index");
            }
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

        [HttpDelete]
        public GeneralResponse CitaCancelar([FromQuery] int? IdCita)
        {

            GeneralResponse response = new();

            try
            {
                var sucess = loginDao.CitaCancelar(IdCita);

                if (sucess)
                {
                    response.Estado = true;
                    response.Mensaje = "Proceso Exitoso";
                }
                else
                {
                    response.Estado = false;
                    response.Mensaje = "Sucedio un error al eliminar la cita";
                }

            }
            catch (Exception ex)
            {
                response.Estado = false;
                response.Mensaje = ex.Message;
            }

            return response;
        }

        [HttpPost]
        public GeneralResponse CitaReprogramar([FromBody] CitaReprogramarRequest request)
        {

            GeneralResponse response = new();

            try
            {
                var sucess = loginDao.CitaReprogramar(request);

                if (sucess)
                {
                    response.Estado = true;
                    response.Mensaje = "Proceso Exitoso";
                }
                else
                {
                    response.Estado = false;
                    response.Mensaje = "Sucedio un error al reprogramar la cita";
                }

            }
            catch (Exception ex)
            {
                response.Estado = false;
                response.Mensaje = ex.Message;
            }

            return response;
        }
    }
}
