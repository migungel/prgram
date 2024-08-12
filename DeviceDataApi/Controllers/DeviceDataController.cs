using DeviceDataApi.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DeviceDataApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeviceDataController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DeviceDataController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetData([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            var sensorDataQuery = _context.ParametroSensores
                .Where(d => d.FechaDato >= startDate && d.FechaDato <= endDate)
                .GroupBy(d => d.CodigoParametro)
                .Select(g => new
                {
                    CodigoParametro = g.Key,
                    AvgData = g.Average(d => d.ValorNumero),
                    MinData = g.Min(d => d.ValorNumero),
                    MaxData = g.Max(d => d.ValorNumero)
                });

            var parameterDescriptions = await _context.ParametrosDescripcion.ToListAsync();

            var response = new
            {
                //device_dates = new[] { $"{startDate:yyyy-MM-dd HH:mm:ss} - {endDate:yyyy-MM-dd HH:mm:ss}" },
                device_dates = new[] { $"{startDate.ToUniversalTime():yyyy-MM-dd HH:mm:ss} - {endDate.ToUniversalTime():yyyy-MM-dd HH:mm:ss}" },
                device_data = parameterDescriptions.Select(p => new
                {
                    codigo_parametro = p.CodigoParametro,
                    nombre_parametro = p.DescripcionLarga,
                    unidad_parametro = p.Unidad,
                    abreviacion_parametro = p.Abreviacion,
                    values = new
                    {
                        avg_data = sensorDataQuery.Where(d => d.CodigoParametro == p.CodigoParametro).Select(d => d.AvgData).ToArray(),
                        min_data = sensorDataQuery.Where(d => d.CodigoParametro == p.CodigoParametro).Select(d => d.MinData).ToArray(),
                        max_data = sensorDataQuery.Where(d => d.CodigoParametro == p.CodigoParametro).Select(d => d.MaxData).ToArray()
                    }
                })
            };

            return Ok(response);
        }
    }
}
