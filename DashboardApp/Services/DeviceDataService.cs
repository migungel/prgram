using DashboardApp.Models;
using System.Text.Json;

namespace DashboardApp.Services
{
    public class DeviceDataService
    {
        private readonly HttpClient _httpClient;

        public DeviceDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<DashboardResponse> GetDeviceDataAsync(DateTime startDate, DateTime endDate)
        {
            var startDateUtc = startDate.ToUniversalTime();
            var endDateUtc = endDate.ToUniversalTime();
            var response = await _httpClient.GetFromJsonAsync<DashboardResponse>(
                $"http://localhost:5204/api/DeviceData?startDate={startDateUtc:yyyy-MM-ddTHH:mm:ss}Z&endDate={endDateUtc:yyyy-MM-ddTHH:mm:ss}Z");

            return response;
        }
    }
}
