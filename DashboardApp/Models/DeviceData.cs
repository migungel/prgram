using System.Text.Json.Serialization;

namespace DashboardApp.Models
{
    //public class DeviceData
    //{
    //    public string CodigoParametro { get; set; }
    //    public string NombreParametro { get; set; }
    //    public string UnidadParametro { get; set; }
    //    public string AbreviacionParametro { get; set; }
    //    public Values Values { get; set; }
    //}

    public class DeviceData
    {
        [JsonPropertyName("codigo_parametro")]
        public int CodigoParametro { get; set; }
        [JsonPropertyName("nombre_parametro")]
        public string NombreParametro { get; set; }
        [JsonPropertyName("unidad_parametro")]
        public string UnidadParametro { get; set; }
        [JsonPropertyName("abreviacion_parametro")]
        public string AbreviacionParametro { get; set; }
        [JsonPropertyName("values")]
        public DeviceValues Values { get; set; }

    }

    public class DeviceValues
    {
        [JsonPropertyName("avg_data")]
        public List<double> AvgData { get; set; }

        [JsonPropertyName("min_data")]
        public List<double> MinData { get; set; }

        [JsonPropertyName("max_data")]
        public List<double> MaxData { get; set; }
    }

    public class DashboardResponse
    {
        public List<string> DeviceDates { get; set; } = new List<string>();
        public List<DeviceData> DeviceData { get; set; } = new List<DeviceData>();
    }
}
