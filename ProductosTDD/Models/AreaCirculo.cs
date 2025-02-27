namespace ProductosTDD.Models
{
    public class AreaCirculo
    {
        public double Radio { get; set; }
        public double CalcularArea()
        {
            return Math.PI * Math.Pow(Radio, 2);
        }
    }
}
