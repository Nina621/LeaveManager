using AutoMapper;
using LeaveManager.Data;
using LeaveManagment.Models;

namespace LeaveManagment.Mapper
{
    public class Mapp : Profile
    {
        public Mapp() {

            CreateMap<LeaveTypeManager, LeaveTypeModel>().ReverseMap();

            CreateMap<LeaveAllocation, LeaveAllocationModel>().ReverseMap();

            CreateMap<Employees, EmployeesModel>().ReverseMap();
        }
       
       
    }
}
