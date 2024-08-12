using DashboardApp.Models;
using DashboardApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace DashboardApp.Controllers
{
    public class DashboardController : Controller
    {
        private readonly DeviceDataService _deviceDataService;

        public DashboardController(DeviceDataService deviceDataService)
        {
            _deviceDataService = deviceDataService;
        }

        public async Task<IActionResult> Index(DateTime? startDate, DateTime? endDate)
        {
            if (!startDate.HasValue || !endDate.HasValue)
            {
                startDate = DateTime.Now.AddMonths(-1);
                endDate = DateTime.Now;
            }

            var data = await _deviceDataService.GetDeviceDataAsync(startDate.Value, endDate.Value);
            ViewData["StartDate"] = startDate.Value.ToString("yyyy-MM-dd");
            ViewData["EndDate"] = endDate.Value.ToString("yyyy-MM-dd");
            ViewData["DeviceDataJson"] = JsonSerializer.Serialize(data);
            return View(data);
        }
    }
}
