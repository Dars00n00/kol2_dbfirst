using System.ComponentModel.DataAnnotations;

namespace kol2.DTOs;

public class GetEventDto
{
    [Required]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(150)]
    public string Title { get; set; }
    
    [Required]
    [MaxLength(500)]
    public string Description { get; set; }
    
    [Required]
    public DateTime Date { get; set; }
    
    [Required]
    public GetUserInnerDto Organizer { get; set; }
    
    [Required]
    public List<GetUserInnerDto> Participants { get; set; }
    
    [Required]
    public List<GetTagInnerDto> Tags { get; set; }
}

public class GetUserInnerDto
{
    [Required]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string Username { get; set; }
}

public class GetTagInnerDto
{
    [Required]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
}