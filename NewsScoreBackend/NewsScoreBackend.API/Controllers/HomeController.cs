using Microsoft.AspNetCore.Mvc;
using NewsScoreBackend.API.Models;
using NewsScoreBackend.API.Services;

namespace NewsScoreBackend.API.Controllers;

[Route("api")]
public class HomeController : Controller
{

    [HttpPost]
    [Route("newsscore")]
    public int GetNewsScore([FromBody] Measurements measurements)
    {
        var newsscoreService = new NewsscoreService();
        return newsscoreService.CalculateNewsScore(measurements);
    }
}