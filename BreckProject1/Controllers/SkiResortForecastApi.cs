using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace BreckProject1.Controllers
{
    public class SkiResortForecastApiController : Controller
    {
        private  HttpClient _client;
        private readonly ILogger<SkiResortForecastApiController> _logger;

        public SkiResortForecastApiController(HttpClient client, ILogger<SkiResortForecastApiController> logger)
        {
            _client = client;
            _logger = logger;
            
        }

        public async Task<IActionResult> GetForecast()
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
                _logger.LogInformation(body);
                return Ok(body);
                
            }
        }

    }
}
