using Microsoft.AspNetCore.Mvc;
using RestfulApiExample.Models;
using RestfulApiExample.Services;

[ApiController]
[Route("[controller]")]
public class AdvertController : ControllerBase
{
    private readonly IAdvertService _advertService;

    public AdvertController(IAdvertService advertService)
    {
        _advertService = advertService;
    }

    [HttpGet("all")]
    public IActionResult GetAllAdverts([FromQuery] AdvertFilter filter)
    {
        try
        {
            var adverts = _advertService.GetAdverts(filter);
            if (adverts == null || adverts.Count == 0)
                return NoContent();

            return Ok(new { total = adverts.Count, page = filter.Page, adverts });
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Internal Server Error");
        }
    }

    [HttpGet("get")]
    public IActionResult GetAdvertById([FromQuery] int id)
    {
        try
        {
            var result = _advertService.GetAdvertById(id);
            if (result == null)
                return NoContent();

            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Internal Server Error");
        }
    }

    [HttpPost("visit")]
    public IActionResult AddVisit([FromBody] VisitRequest request)
    {
        try
        {
            _advertService.AddVisit(request.AdvertId, HttpContext.Connection.RemoteIpAddress.ToString());
            return StatusCode(201, new { Message = "Visit created" });
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Internal Server Error");
        }
    }
}