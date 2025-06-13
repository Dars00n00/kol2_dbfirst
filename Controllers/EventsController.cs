using kol2.DTOs;
using kol2.Exceptions;
using kol2.Services;
using Microsoft.AspNetCore.Mvc;


namespace kol2.Controllers;


[ApiController]
[Route("api/[controller]/details")]
public class EventsController : ControllerBase
{
    private readonly IEventsService _eventsService;

    public EventsController(IEventsService eventsService)
    {
        _eventsService = eventsService;
    }


    [HttpGet]
    public async Task<IActionResult> GetEventsDetailsAsync()
    {
        try
        {
            var result = await _eventsService.GetAllEventsAsync();
            return Ok(result);
        }
        catch (NoEventsFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }


    [HttpPut("{id}")]
    public async Task<object> PutModifiedEventAsync([FromRoute] int id, [FromBody] PutEventDto eventDto)
    {
        try
        {
            var result = await _eventsService.PutEventAsync(id, eventDto);
            return Ok(result);
        }
        catch (NoEventFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
    
}