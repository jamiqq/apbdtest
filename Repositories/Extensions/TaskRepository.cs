using ApbdTestAPI.Entities;
using ApbdTestAPI.Repositories.Abstract;
using Microsoft.Data.SqlClient;

namespace ApbdTestAPI.Repositories.Extensions;

public class TaskRepository : BaseRepository, ITaskRepository
{
    public TaskRepository(string connectionString) : base(connectionString)
    {
    }

    // public async Task<List<Task>> GetTasksAssignedTo(int userId, CancellationToken cancellationToken = default)
    // {
    //     var tasks = new List<TaskEntity>();
    //
    //     const string query = """
    //                          SELECT t.Name, t.Description, t.Deadline, p.Name AS ProjectName, tt.Name AS TaskTypeName
    //                          FROM Tasks t
    //                          JOIN Projects p ON t.IdProject = p.Id
    //                          JOIN TaskTypes tt ON t.IdTaskType = tt.Id
    //                          WHERE t.IdAssignedTo = @UserId
    //                          ORDER BY t.Deadline DESC
    //                          """;
    //     await using SqlConnection conn = GetConnection();
    //     await conn.OpenAsync(cancellationToken);
    //     
    //     await using SqlCommand command = new SqlCommand(query, conn);
    //     command.Parameters.AddWithValue("@UserId", userId);
    //     await using var reader = await command.ExecuteReaderAsync(cancellationToken);
    //     while (await reader.ReadAsync(cancellationToken))
    //     {
    //         tasks.Add(new TaskEntity
    //         {
    //             Id = reader.GetInt32(reader.GetOrdinal("Id")),
    //             Name = reader.GetString(reader.GetOrdinal("Name")),
    //             Description = reader.GetString(reader.GetOrdinal("Description")),
    //             Deadline = reader.GetDateTime(reader.GetOrdinal("Deadline")),
    //             Project = reader.GetString(reader.GetOrdinal("ProjectName")),
    //             Type = reader.GetString(reader.GetOrdinal("TaskTypeName")),
    //             
    //         });
    //     }
    //     
    //     return tasks;
    // }
    //
    // public async Task<List<TaskEntity>> GetTasksCreatedBy(int userId)
    // {
    //     var tasks = new List<TaskEntity>();
    //
    //     using (SqlConnection conn = new SqlConnection(_connectionString))
    //     {
    //         string query = @"
    //             SELECT t.Name, t.Description, t.Deadline, p.Name AS ProjectName, tt.Name AS TaskTypeName
    //             FROM Tasks t
    //             JOIN Projects p ON t.IdProject = p.Id
    //             JOIN TaskTypes tt ON t.IdTaskType = tt.Id
    //             WHERE t.IdCreator = @UserId
    //             ORDER BY t.Deadline DESC";
    //
    //         using (SqlCommand cmd = new SqlCommand(query, conn))
    //         {
    //             cmd.Parameters.AddWithValue("@UserId", userId);
    //             conn.Open();
    //
    //             using (SqlDataReader reader = cmd.ExecuteReader())
    //             {
    //                 while (reader.Read())
    //                 {
    //                     tasks.Add(new TaskEntity()
    //                     {
    //                         Name = reader["Name"].ToString(),
    //                         Description = reader["Description"].ToString(),
    //                         Deadline = Convert.ToDateTime(reader["Deadline"]),
    //                         Project = reader["ProjectName"].ToString(),
    //                         TaskTypeName = reader["TaskTypeName"].ToString()
    //                     });
    //                 }
    //             }
    //         }
    //     }
    //
    //     return tasks;
    // }
    //
    // public int CreateTask(TaskModel task)
    // {
    //     using (SqlConnection conn = new SqlConnection(_connectionString))
    //     {
    //         string query = @"
    //             INSERT INTO Tasks (Name, Description, Deadline, IdTeam, IdTaskType, IdAssignedTo, IdCreator, IdProject)
    //             VALUES (@Name, @Description, @Deadline, @IdTeam, @IdTaskType, @IdAssignedTo, @IdCreator, @IdProject);
    //             SELECT SCOPE_IDENTITY();";
    //
    //         using (SqlCommand cmd = new SqlCommand(query, conn))
    //         {
    //             cmd.Parameters.AddWithValue("@Name", task.Name);
    //             cmd.Parameters.AddWithValue("@Description", task.Description);
    //             cmd.Parameters.AddWithValue("@Deadline", task.Deadline);
    //             cmd.Parameters.AddWithValue("@IdTeam", task.IdTeam);
    //             cmd.Parameters.AddWithValue("@IdTaskType", task.IdTaskType);
    //             cmd.Parameters.AddWithValue("@IdAssignedTo", task.IdAssignedTo);
    //             cmd.Parameters.AddWithValue("@IdCreator", task.IdCreator);
    //             cmd.Parameters.AddWithValue("@IdProject", task.IdProject);
    //
    //             conn.Open();
    //             return Convert.ToInt32(cmd.ExecuteScalar());
    //         }
    //     }
    // }
    public async Task<TaskEntity> GetTaskByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return null;
    }
    public async Task<int> AddTaskAsync(TaskEntity task, CancellationToken cancellationToken = default)
    {
        const string query = """
                             INSERT INTO Task(
                             IdProject, IdTaskType, IdAssignedTo,IdCreator, Name, Description, Deadline
                             )
                             OUTPUT INSERTED.IdProject
                             VALUES (@Project, @TaskType, @IdAssignedTo, @IdCreator, @Name, @Description, @Deadline)
                             """;
        
        await using SqlConnection conn = GetConnection();
        await conn.OpenAsync(cancellationToken);
        
        await using SqlCommand command = new SqlCommand(query, conn);
        command.Parameters.AddWithValue("@Project", task.Project);
        command.Parameters.AddWithValue("@TaskType", task.Type);
        command.Parameters.AddWithValue("@IdAssignedTo", task.AssignedTo);
        command.Parameters.AddWithValue("@IdCreator", task.Creator);
        command.Parameters.AddWithValue("@Name", task.Name);
        command.Parameters.AddWithValue("@Description", task.Description);
        command.Parameters.AddWithValue("@Deadline", task.Deadline);
        
        var result = await command.ExecuteNonQueryAsync(cancellationToken);
        return (int)result;
    }
}
