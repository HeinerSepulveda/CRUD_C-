using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DirectorioTelefonico
{
    public class DataDirectorio
    {
        private string connectionString
            = "Data Source=DESKTOP-76QT684\\SQLEXPRESS; Initial Catalog=directoriotelefonico;User=Heiner;Password=123456";

        public bool ProbarConexion()
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public List<Directorio> Get()
        {
            List<Directorio> directorio = new List<Directorio>();
            string sql = "SELECT id,Nombre,Apellido,NroDocumento,Celular,Cargo,NroOficina FROM Directorio";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Directorio datosDirectorio = new Directorio();
                        datosDirectorio.id = reader.GetInt32(0);
                        datosDirectorio.Nombre = reader.GetString(1);
                        datosDirectorio.Apellido = reader.GetString(2);
                        datosDirectorio.NroDocumento = reader.GetString(3);
                        datosDirectorio.Celular = reader.GetString(4);
                        datosDirectorio.Cargo = reader.GetString(5);
                        datosDirectorio.NroOficina = reader.GetInt32(6);
                        directorio.Add(datosDirectorio);

                    }
                    reader.Close();
                    connection.Close();

                }
                catch (Exception e)
                {
                    throw new Exception("Hay un error en la base de datos" +e.Message);
                }
            }

            return directorio;
        }

        public void Agregar(string Nombre, string Apellido, string NroDocumento, string Celular, string Cargo, int NroOficina)
        {
            string sql = "INSERT INTO Directorio (Nombre,Apellido,NroDocumento,Celular,Cargo,NroOficina) VALUES (@Nombre,@Apellido,@NroDocumento,@Celular,@Cargo,@NroOficina)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@Nombre", Nombre);
                command.Parameters.AddWithValue("@Apellido", Apellido);
                command.Parameters.AddWithValue("@NroDocumento", NroDocumento);
                command.Parameters.AddWithValue("@Celular", Celular);
                command.Parameters.AddWithValue("@Cargo", Cargo);
                command.Parameters.AddWithValue("@NroOficina", NroOficina);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();

                }
                catch (Exception e)
                {
                    throw new Exception("Hay un error en la base de datos" + e.Message);
                }
            }
        }

        public void Editar(string Nombre, string Apellido, string NroDocumento, string Celular, string Cargo, int NroOficina, int id)
        {
            string sql = "UPDATE Directorio SET Nombre=@Nombre,Apellido=@Apellido,NroDocumento=@NroDocumento," +
                "Celular=@Celular,Cargo=@Cargo,NroOficina=@NroOficina WHERE id=@id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@Nombre", Nombre);
                command.Parameters.AddWithValue("@Apellido", Apellido);
                command.Parameters.AddWithValue("@NroDocumento", NroDocumento);
                command.Parameters.AddWithValue("@Celular", Celular);
                command.Parameters.AddWithValue("@Cargo", Cargo);
                command.Parameters.AddWithValue("@NroOficina", NroOficina);
                command.Parameters.AddWithValue("@id", id);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();

                }
                catch (Exception e)
                {
                    throw new Exception(" Error al actualizar empleado" + e.Message);
                }
            }
        }

        public Directorio Get(int? id)
        {
            string sql = "SELECT id,Nombre,Apellido,NroDocumento,Celular,Cargo,NroOficina FROM Directorio WHERE id=@id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@id", id);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();

                    Directorio datosDirectorio = new Directorio();
                    datosDirectorio.id = reader.GetInt32(0);
                    datosDirectorio.Nombre = reader.GetString(1);
                    datosDirectorio.Apellido = reader.GetString(2);
                    datosDirectorio.NroDocumento = reader.GetString(3);
                    datosDirectorio.Celular = reader.GetString(4);
                    datosDirectorio.Cargo = reader.GetString(5);
                    datosDirectorio.NroOficina = reader.GetInt32(6);

                    reader.Close();
                    connection.Close();

                    return datosDirectorio;



                }
                catch (Exception e)
                {
                    throw new Exception("Hay un error en la base de datos" + e.Message);
                }
            }
        }

        public void Eliminar(int id)
        {
            string sql = "DELETE FROM Directorio WHERE id=@id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@id", id);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();

                }
                catch (Exception e)
                {
                    throw new Exception(" Error al actualizar empleado: " + e.Message);
                }
            }
        }

    }
    public class Directorio{
        public int id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }   
        public string NroDocumento { get; set; }   
        public string Celular { get; set; }   
        public string Cargo { get; set; }   
        public int NroOficina { get; set; }   
    }
}
