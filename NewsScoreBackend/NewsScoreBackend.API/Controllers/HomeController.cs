using Microsoft.AspNetCore.Mvc;
using NewsScoreBackend.API.Models;
using NewsScoreBackend.API.Services;

namespace NewsScoreBackend.API.Controllers;

[Route("api")]
public class HomeController : Controller
{

    private NewsscoreService _newsscoreService;

    public HomeController(NewsscoreService newsscoreService)
    {
        _newsscoreService = newsscoreService;
    }
    
    [HttpPost]
    [Route("newsscore")]
    //retur type må oppdateres
    public ActionResult<Newsscore> GetNewsScore([FromBody] MeasurementList measurementList)
    {
        try
        {
            var score = _newsscoreService.CalculateNewsScore(measurementList);
            return Ok(score);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}