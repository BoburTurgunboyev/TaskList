using AutoMapper;
using TaskList.Infrastructure.Repositories.TaskRepo;
using Task = TaskList.Domain.Entities.Task;

namespace TaskList.Application.Services.TaskServ
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;

        public TaskService(ITaskRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        public async ValueTask<Task> Add(Task repo)
        {
            var result =await _taskRepository.Insert(repo);
            return result;
        }

        public async ValueTask<Task> Modify(Task repo)
        {
            var result = await _taskRepository.Update(repo);
            return result;
        }

        public async ValueTask<Task> RemoveById(int Id)
        {
            var task = await _taskRepository.DeleteById(Id);
            return task;
        }

        public async ValueTask<IEnumerable<Task>> RetrieveAll()
        {
            var task = await _taskRepository.SelectAll();
            return task;
        }

        public async ValueTask<Task> RetrieveById(int Id)
        {
            var task = await _taskRepository.SelectById(Id);
            return task;
        }
    }
}
