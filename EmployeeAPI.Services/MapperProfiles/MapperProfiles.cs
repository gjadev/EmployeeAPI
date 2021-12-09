using AutoMapper;
using EmployeeAPI.Services.Dtos;
using EmployeeAPI.Data.Entities;

namespace EmployeeAPI.Services.MapperProfiles
{
    public class MapperProfiles: Profile
    {
        public MapperProfiles()
        {
            CreateMap<Employee, EmployeeDto>().ReverseMap();
        }
    }
}
