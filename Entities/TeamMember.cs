namespace ApbdTestAPI.Entities;

public class TeamMember : BaseEntity
{
    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;
    
    public string Email { get; set; } = string.Empty;
    
    public ICollection<TaskEntity>? AssignedTo { get; set; }
    
    public ICollection<TaskEntity>? Creators { get; set; }
}