using Task = TaskList.Domain.Entities.Task;
namespace TaskList.Infrastructure.Repositories.TaskRepo;
public interface ITaskRepository : IBaseRepository<Task>
{
}
