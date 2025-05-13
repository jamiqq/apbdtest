namespace ApbdTestAPI.Entities;

public class TaskEntity : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    
    public string Description { get; set; } = string.Empty;
    
    public DateTime Deadline { get; set; }

    public Project Project { get; set; } = null!;

    public TaskType Type { get; set; } = null!;
    
    public TeamMember AssignedTo { get; set; } = null!;
    
    public TeamMember Creator { get; set; } = null!;
}