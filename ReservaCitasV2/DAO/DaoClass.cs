using MySql.Data.MySqlClient;
using ReservaCitasV2.Data;
using ReservaCitasV2.Models.CitasEntities;
using System.Data;

namespace ReservaCitasV2.DAO
{
    public class DaoClass
    {
        readonly string connection = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build()["ConnectionString"] ?? "";

        public LoginResponse Login(string? usuario, string? pass)
        {
            LoginResponse? response = null;

            try
            {
                using (MySqlConnection cn = new MySqlConnection(connection))
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cn.Open();
                    cmd.Connection = cn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = @"SP_ACCOUNT_LOGIN";

                    cmd.Parameters.Add("@PARAM_VC_DNI", MySqlDbType.VarChar).Value = usuario;
                    cmd.Parameters.Add("@PARAM_VC_PASSWORD", MySqlDbType.Text).Value = pass;

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response = new();

                            response.IdUsuario = Convert.ToInt32(reader["ID_PACIENTE"]);
                            response.Dni = Convert.ToString(reader["VC_DNI"]);
                            response.Pass = Convert.ToString(reader["VC_PASS"]);
                        }
                    }

                    cn.Close();
                    cn.Dispose();
                }


                if (response == null)
                {
                    response = new();

                    response.Estado = false;
                    response.Mensaje = "Usuario o contraseña incorrectos";
                }
                else
                {
                    response.Estado = true;
                    response.Mensaje = "Bienvenido";
                }
            }
            catch
            {
                response = new();

                response.Estado = false;
                response.Mensaje = "Error en el sistema";
            }

            return response;
        }

        public Paciente ObtenerUsuario(int? IdUsuario)
        {
            Paciente response = new();

            try
            {
                using (MySqlConnection cn = new MySqlConnection(connection))
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cn.Open();
                    cmd.Connection = cn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = @"SP_USUARIO_OBTENER";

                    cmd.Parameters.Add("@PARAM_ID_USUARIO", MySqlDbType.Int32).Value = IdUsuario;

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.IdUsuario = Convert.ToInt32(reader["ID_PACIENTE"]);
                            response.Nombre = Convert.ToString(reader["VC_NOMBRE"]);
                            response.Edad = Convert.ToString(reader["VC_EDAD"]);
                            response.Sexo = Convert.ToString(reader["VC_SEXO"]);
                            response.Seguro = Convert.ToString(reader["VC_SEGURO"]);
                            response.Peso = Convert.ToString(reader["VC_PESO"]);
                            response.Altura = Convert.ToString(reader["VC_ALTURA"]);
                            response.Dni = Convert.ToString(reader["VC_DNI"]);
                            response.Pass = Convert.ToString(reader["VC_PASS"]);
                        }
                    }

                    cn.Close();
                    cn.Dispose();
                }


            }
            catch
            {

            }

            return response;
        }

        public List<Doctor> DoctoresListar()
        {
            List<Doctor> response = new();

            try
            {
                using (MySqlConnection cn = new MySqlConnection(connection))
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cn.Open();
                    cmd.Connection = cn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = @"SP_DOCTOR_LISTAR";

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Doctor e = new();

                            e.Id = Convert.ToInt32(reader["ID_DOCTOR"]);
                            e.Name = Convert.ToString(reader["VC_NOMBRE"]);
                            e.IdEspecialidad = Convert.ToInt32(reader["IN_ID_ESPECIALIDAD"]);
                            e.NombreEspecialidad = Convert.ToString(reader["NOMBRE_ESPECIALIDAD"]);

                            response.Add(e);
                        }
                    }

                    cn.Close();
                    cn.Dispose();
                }
            }
            catch
            {

            }

            return response;
        }
        
        public List<Especialidad> EspecialidadListar()
        {
            List<Especialidad> response = new();

            try
            {
                using (MySqlConnection cn = new MySqlConnection(connection))
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cn.Open();
                    cmd.Connection = cn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = @"SP_ESPECIALIDAD_LISTAR";

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Especialidad e = new();

                            e.Id = Convert.ToInt32(reader["ID_ESPECIALIDAD"]);
                            e.Name = Convert.ToString(reader["VC_NOMRBE"]);

                            response.Add(e);
                        }
                    }

                    cn.Close();
                    cn.Dispose();
                }
            }
            catch
            {

            }

            return response;
        }

        public bool CitaRegistrar(CitaCrearRequest request)
        {
            bool response = false;

            try
            {
                using (MySqlConnection cn = new MySqlConnection(connection))
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cn.Open();
                    cmd.Connection = cn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = @"SP_CITA_CREAR";

                    cmd.Parameters.Add("@PARAM_IN_ID_DOCTOR", MySqlDbType.Int32).Value = request.IdDoctor;
                    cmd.Parameters.Add("@PARAM_IN_ID_PACIENTE", MySqlDbType.Int32).Value = request.IdPaciente;
                    cmd.Parameters.Add("@PARAM_IN_ID_LOCAL", MySqlDbType.Int32).Value = request.IdLocal;
                    cmd.Parameters.Add("@PARAM_DT_FECHA", MySqlDbType.Date).Value = request.Fecha;
                    cmd.Parameters.Add("@PARAM_HR_HORA", MySqlDbType.Time).Value = request.Hora;
                    cmd.Parameters.Add("@PARAM_IN_ID_ESPECIALIDAD", MySqlDbType.Int32).Value = request.IdEspecialidad;

                    cmd.ExecuteNonQuery();

                    response = true;

                    cn.Close();
                    cn.Dispose();
                }
            }
            catch
            {

            }

            return response;
        }

        public List<Local> LocalListar()
        {
            List<Local> response = new();

            try
            {
                using (MySqlConnection cn = new MySqlConnection(connection))
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cn.Open();
                    cmd.Connection = cn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = @"SP_LOCAL_LISTAR";

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Local e = new();

                            e.Id = Convert.ToInt32(reader["ID_LOCAL"]);
                            e.Name = Convert.ToString(reader["VC_NOIMBRE"]);
                            e.Address = Convert.ToString(reader["VC_DIRECCION"]);

                            response.Add(e);
                        }
                    }

                    cn.Close();
                    cn.Dispose();
                }
            }
            catch
            {

            }

            return response;
        }
    }
}
