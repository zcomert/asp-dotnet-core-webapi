using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects;

namespace ProjectManagement.Utilities.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Project, ProjectDto>().ReverseMap();
            CreateMap<Employee, EmployeeDto>();
            CreateMap<ProjectDtoForCreation, Project>();
        }
    }
}
