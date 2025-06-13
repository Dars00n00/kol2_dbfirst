using kol2.Data;
using kol2.DTOs;
using kol2.Exceptions;
using Microsoft.EntityFrameworkCore;


namespace kol2.Services;


public class EventsService : IEventsService
{
    private readonly _2019sbdContext _context;

    public EventsService(_2019sbdContext context)
    {
        _context = context;
    }
    
    public async Task<List<GetEventDto>> GetAllEventsAsync()
    {
        var result = await _context
            .K2prEvents
            .Select(e => new GetEventDto
            {
                Id = e.Id,
                Title = e.Title,
                Description = e.Description,
                Date = e.Date,
                Organizer = new GetUserInnerDto
                {
                    Id = e.Organizer.Id,
                    Username = e.Organizer.Username
                },
                Participants = e.Users
                    .Select(p => new GetUserInnerDto
                    {
                        Id = p.Id,
                        Username = p.Username,
                    }).ToList(),
                Tags = e.Tags
                    .Select(t => new GetTagInnerDto
                    {
                        Id = t.Id,
                        Name = t.Name,
                    }).ToList()
            })
            .ToListAsync();
        
        if (!result.Any())
        {
            throw new NoEventsFoundException("no events found");
        }

        return result;
    }
    
    public async Task<object> PutEventAsync(int id, PutEventDto eventDto)
    {
        var transaction = await _context.Database.BeginTransactionAsync();

        try
        {
            var eventEntity = await _context.K2prEvents
                .Include(e => e.Tags)
                .Include(e => e.Users)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (eventEntity == null)
            {
                throw new NoEventFoundException($"no event with id={id} found");
            }

            var newTags = await _context.K2prTags
                .Where(t => eventDto.TagIds.Contains(t.Id))
                .ToListAsync();
            if (newTags.Count != eventDto.TagIds.Count)
            {
                var missingTagIds = eventDto.TagIds
                    .Except(newTags.Select(t => t.Id))
                    .ToList();
                if (missingTagIds.Any())
                {
                    throw new MissingTagException(
                        $"missing tags from request: {{ids:{string.Join(", ", missingTagIds)}}} in database");
                }
            }

            var newUsers = await _context.K2prUsers
                .Where(p => eventDto.ParticipantIds.Contains(p.Id))
                .ToListAsync();
            if (newUsers.Count != eventDto.ParticipantIds.Count)
            {
                var missingUserIds = eventDto.ParticipantIds
                    .Except(newUsers.Select(u => u.Id))
                    .ToList();
                if (missingUserIds.Any())
                {
                    throw new MissingUserException($"missing users from request: {{ids:{string.Join(", ", missingUserIds)}}} in database");
                }
            }

            eventEntity.Title = eventDto.Title;
            eventEntity.Description = eventDto.Description;
            eventEntity.Date = eventDto.Date;

            var tagsToRemove = eventEntity.Tags
                .Where(t => !eventDto.TagIds.Contains(t.Id))
                .ToList();
            foreach (var tag in tagsToRemove)
            {
                eventEntity.Tags.Remove(tag);
            }

            foreach (var newTag in newTags)
            {
                if (!eventEntity.Tags.Contains(newTag))
                {
                    eventEntity.Tags.Add(newTag);
                }
            }

            var usersToRemove = eventEntity.Users
                .Where(u => !eventDto.ParticipantIds.Contains(u.Id))
                .ToList();
            foreach (var user in usersToRemove)
            {
                eventEntity.Users.Remove(user);
            }

            foreach (var newUser in newUsers)
            {
                if (!eventEntity.Users.Contains(newUser))
                {
                    eventEntity.Users.Add(newUser);
                }
            }

            await _context.SaveChangesAsync();

            await transaction.CommitAsync();
            
            return new
            {
                message = "Wydarzenie zaktualizowane pomyślnie.",
                eventId = id,
                updatedTags = newTags
                    .Select(t => new { t.Id, t.Name })
                    .ToList(),
                updatedParticipants = newUsers
                    .Select(u => new { u.Id, u.Username })
                    .ToList()
            };
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            throw;
        }
    }
    
}