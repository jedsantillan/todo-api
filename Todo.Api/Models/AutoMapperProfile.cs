using AutoMapper;
using Todo.Domain.Entities;

namespace Todo.Api.Models
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // This maps the DTO to Entity
            CreateMap<TodoTaskRequest, TodoTask>();
        }
        
    }
}
