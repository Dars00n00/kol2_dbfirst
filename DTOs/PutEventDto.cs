using System.ComponentModel.DataAnnotations;

namespace kol2.DTOs;

public class PutEventDto
{
    [Required] [MaxLength(150)] public string Title { get; set; }

    [Required] [MaxLength(500)] public string Description { get; set; }

    [Required] public DateTime Date { get; set; }

    [Required] public List<int> TagIds { get; set; }

    [Required] public List<int> ParticipantIds { get; set; }
}