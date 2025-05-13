namespace ApbdTestAPI.Entities;

public class Project : BaseEntity
{
    public string Name { get; set; }
    
    public DateTime Deadline { get; set; }
    
    public ICollection<TaskEntity> Tasks { get; set; }
}