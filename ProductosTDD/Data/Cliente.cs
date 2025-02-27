using System.ComponentModel.DataAnnotations;
namespace ProductosTDD.Data
{
    public class Cliente
    {
        [Required]
        public int Codigo { get; set; }
        [Required]
        public required string Cedula { get; set; }
        [Required]
        public required string Nombres { get; set; }
        [Required]
        public required string Apellidos { get; set; }
        [Required]
        public DateTime FechaNacimiento { get; set; }
        [Required]
        public required string Mail { get; set; }
        [Required]
        public required string Telefono { get; set; }
        [Required]
        public required string Direccion { get; set; }
        [Required]
        public Boolean Estado { get; set; }

        public Cliente()
        {
        }
    }

}
