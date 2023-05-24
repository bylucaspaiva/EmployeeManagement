using AutoMapper;
using EmployeeManagement.Models;
using EmployeeManagement.DTOs;

namespace EmployeeManagement.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<EmployeeDTO, Employee>();
            CreateMap<Employee, EmployeeDTO>();

        }
    }
}
