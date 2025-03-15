using Microsoft.AspNetCore.Mvc;
using NewsScoreBackend.API.Models;
using NewsScoreBackend.API.Services;

namespace NewsScoreBackend.API.Controllers;

[Route("api")]
public class HomeController : Controller
{

    [HttpPost]
    [Route("newsscore")]
    public ActionResult<int> GetNewsScore([FromBody] Measurements measurements)
    {
        var newsscoreService = new NewsscoreService();
        try
        {
            var score = newsscoreService.CalculateNewsScore(measurements);
            return Ok(score);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}