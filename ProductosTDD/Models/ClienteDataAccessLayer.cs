using ProductosTDD.Data;
using System.Data.SqlClient;

namespace ProductosTDD.Models
{
    public class ClienteDataAccessLayer
    {
        string connectionString = "Server=localhost; Database=dbproductos; User ID=sa; Password=147258369Qw*; TrustServerCertificate=true; MultipleActiveResultSets=true";

        public List<Cliente> getAllCliente()
        {
            List<Cliente> lstCliente = new List<Cliente>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Cliente_SelectAll", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Cliente cliente = new Cliente
                    {
                        Codigo = Convert.ToInt32(rdr["Codigo"]),
                        Cedula = rdr["Cedula"].ToString(),
                        Nombres = rdr["Nombres"].ToString(),
                        Apellidos = rdr["Apellidos"].ToString(),
                        FechaNacimiento = Convert.ToDateTime(rdr["FechaNacimiento"]),
                        Mail = rdr["Mail"].ToString(),
                        Telefono = rdr["Telefono"].ToString(),
                        Direccion = rdr["Direccion"].ToString(),
                        Estado = Convert.ToBoolean(rdr["Estado"])
                    };
                    lstCliente.Add(cliente);
                }
                con.Close();
            }
            return lstCliente;
        }

        public void AddClient(Cliente Cliente)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Cliente_Insert", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@cedula", Cliente.Cedula);
                cmd.Parameters.AddWithValue("@nombres", Cliente.Nombres);
                cmd.Parameters.AddWithValue("@apellidos", Cliente.Apellidos);
                cmd.Parameters.AddWithValue("@FechaNacimiento", Cliente.FechaNacimiento);
                cmd.Parameters.AddWithValue("@mail", Cliente.Mail);
                cmd.Parameters.AddWithValue("@telefono", Cliente.Telefono);
                cmd.Parameters.AddWithValue("@direccion", Cliente.Direccion);
                cmd.Parameters.AddWithValue("@estado", Cliente.Estado);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void UpdateClient(Cliente Cliente)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Cliente_Update", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Codigo", Cliente.Codigo);
                cmd.Parameters.AddWithValue("@Cedula", Cliente.Cedula);
                cmd.Parameters.AddWithValue("@Nombres", Cliente.Nombres);
                cmd.Parameters.AddWithValue("@Apellidos", Cliente.Apellidos);
                cmd.Parameters.AddWithValue("@FechaNacimiento", Cliente.FechaNacimiento);
                cmd.Parameters.AddWithValue("@Mail", Cliente.Mail);
                cmd.Parameters.AddWithValue("@Telefono", Cliente.Telefono);
                cmd.Parameters.AddWithValue("@Direccion", (object)Cliente.Direccion ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Estado", Cliente.Estado);

                con.Open();
                int result = cmd.ExecuteNonQuery();
                con.Close();

                if (result == 0)
                {
                    throw new Exception("No se pudo actualizar el cliente. Verifique el código ingresado.");
                }
            }
        }
        public bool DeleteClient(int codigo)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Cliente_Delete", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Codigo", codigo);

                con.Open();
                int result = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();

                return result == 1; // Devuelve true si se eliminó correctamente
            }
        }
    }
}
