namespace DeviceDataApi.Models
{
    public class ParameterDescription
    {
        public int Id { get; set; }
        public int CodigoParametro { get; set; }
        public string DescripcionLarga { get; set; }
        public string DescripcionMed { get; set; }
        public string DescripcionCorta { get; set; }
        public string Abreviacion { get; set; }
        public string Observacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string Estado { get; set; }
        public string Unidad { get; set; }
    }
}
