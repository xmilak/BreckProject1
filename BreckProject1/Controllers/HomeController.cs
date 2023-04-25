using BreckProject1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.MSIdentity.Shared;
using MySqlX.XDevAPI;
using Newtonsoft.Json;
using System.Diagnostics;

namespace BreckProject1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private HttpClient _client;

        public HomeController(HttpClient client, ILogger<HomeController> logger)
        {
            _logger = logger;
            _client = client;
        }

        public async Task<IActionResult> Index()
        {
            var request = new HttpRequestMessage
            {

                Method = HttpMethod.Get,
                RequestUri = new Uri("https://ski-resort-forecast.p.rapidapi.com/Breckenridge/forecast?units=m&el=top"),
                Headers =
                {
                    { "X-RapidAPI-Key", "34dfdc0730mshe2668bf004a71a6p1eaaf1jsn59d120fa36b0" },
                    { "X-RapidAPI-Host", "ski-resort-forecast.p.rapidapi.com" },
                },
            };
            using (var response = await _client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<ForecastViewModel>(body);
                _logger.LogInformation(body);
                return View(data);
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}