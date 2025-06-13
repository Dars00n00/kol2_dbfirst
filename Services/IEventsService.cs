using kol2.DTOs;

namespace kol2.Services;

public interface IEventsService
{
    Task<List<GetEventDto>> GetAllEventsAsync();
    
    Task<object> PutEventAsync(int id, PutEventDto eventDto);
}