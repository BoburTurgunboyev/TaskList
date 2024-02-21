using Task = TaskList.Domain.Entities.Task;
namespace TaskList.Application.Services.TaskServ;

public interface ITaskService
{
    public ValueTask<Task> RetrieveById(int Id);
    public ValueTask<IEnumerable<Task>> RetrieveAll();
    public ValueTask<Task> Add(Task repo);
    public ValueTask<Task> Modify(Task repo);
    public ValueTask<Task> RemoveById(int Id);
}
