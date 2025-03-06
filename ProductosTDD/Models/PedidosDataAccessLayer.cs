using ProductosTDD.Data;
using System.Data.SqlClient;
using System.Data;

namespace ProductosTDD.Models
{
    public class PedidosDataAccessLayer
    {
        private readonly string connectionString = "Server=localhost; Database=dbproductos; User ID=sa; Password=147258369Qw*; TrustServerCertificate=true; MultipleActiveResultSets=true";

        public List<Pedido> GetAllPedidos()
        {
            List<Pedido> pedidos = new List<Pedido>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Pedido_GetAll", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    pedidos.Add(new Pedido
                    {
                        PedidoID = Convert.ToInt32(rdr["PedidoID"]),
                        ClienteID = Convert.ToInt32(rdr["ClienteID"]),
                        FechaPedido = Convert.ToDateTime(rdr["FechaPedido"]),
                        Monto = Convert.ToDecimal(rdr["Monto"]),
                        Estado = rdr["Estado"].ToString()
                    });
                }
                con.Close();
            }
            return pedidos;
        }

        public void AddPedido(Pedido pedido)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Pedido_Insert", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ClienteID", pedido.ClienteID);
                cmd.Parameters.AddWithValue("@Monto", pedido.Monto);
                cmd.Parameters.AddWithValue("@Estado", pedido.Estado ?? "Pendiente");

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void UpdatePedido(Pedido pedido)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Pedido_Update", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@PedidoID", pedido.PedidoID);
                cmd.Parameters.AddWithValue("@ClienteID", pedido.ClienteID);
                cmd.Parameters.AddWithValue("@Monto", pedido.Monto);
                cmd.Parameters.AddWithValue("@Estado", pedido.Estado);

                con.Open();
                int result = cmd.ExecuteNonQuery();
                con.Close();

                if (result == 0)
                {
                    throw new Exception("No se pudo actualizar el pedido. Verifique el ID ingresado.");
                }
            }
        }

        public bool DeletePedido(int pedidoID)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Pedido_Delete", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PedidoID", pedidoID);

                con.Open();
                int result = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();

                return result == 1; // Devuelve true si se eliminó correctamente
            }
        }
    }
}
