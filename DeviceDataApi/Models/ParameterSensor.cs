namespace DeviceDataApi.Models
{
    public class ParameterSensor
    {
        public int Id { get; set; }
        public int CodigoParametro { get; set; }
        public int ParametroSensoresId { get; set; }
        public string NombreParametro { get; set; }
        public DateTime FechaDato { get; set; } 
        public double ValorNumero { get; set; }
    }
}
