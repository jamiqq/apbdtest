namespace ApbdTestAPI.Entities;

public class TaskType : BaseEntity
{
    public string Name { get; set; }
    
    public ICollection<TaskEntity> Tasks { get; set; }
}