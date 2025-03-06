
using System.ComponentModel.DataAnnotations;

namespace ProductosTDD.Data
{
    public class Pedido
    {
        public int PedidoID { get; set; }

        [Required]
        public int ClienteID { get; set; }

        [Required]
        public DateTime FechaPedido { get; set; } = DateTime.Now;

        [Required]
        public decimal Monto { get; set; }

        [Required]
        public string Estado { get; set; } = "Pendiente";
    }
}
