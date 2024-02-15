using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TaskList.Domain.Exceptions;
using TaskList.Infrastructure.Data;
using Task = TaskList.Domain.Entities.Task;

namespace TaskList.Infrastructure.Repositories.TaskRepo
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskDbContext _dbContext;
        private readonly IMapper _mapper;

        public TaskRepository(TaskDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async ValueTask<Task> DeleteById(int Id)
        {
            var task = await _dbContext.Tasks.FirstOrDefaultAsync(t => t.Id == Id);
            if (task == null)
            {
                throw new TaskException();
            }

            var result = _dbContext.Tasks.Remove(task);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async ValueTask<Task> Insert(Task repo)
        {
            var task = await _dbContext.Tasks.AddAsync(repo);
            await _dbContext.SaveChangesAsync();
            return task.Entity;
        }

        public async ValueTask<IEnumerable<Task>> SelectAll()
        {
            var task = await _dbContext.Tasks.AsNoTracking().ToListAsync();
            return task;
        }

        public async ValueTask<Task> SelectById(int Id)
        {
            var task = await _dbContext.Tasks.FirstOrDefaultAsync(t => t.Id == Id);
            return task;
        }

        public async ValueTask<Task> Update(Task repo)
        {
            var task = await _dbContext.Tasks.FirstOrDefaultAsync(x => x.Id == repo.Id);
            task = _mapper.Map<Task>(repo);
            var result = _dbContext.Update(task);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }
    }
}
