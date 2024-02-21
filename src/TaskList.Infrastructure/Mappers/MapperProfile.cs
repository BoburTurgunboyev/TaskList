using AutoMapper;

using Task = TaskList.Domain.Entities.Task;

namespace TaskList.Infrastructure.Mappers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Task,Task>();

        }

    }
}
