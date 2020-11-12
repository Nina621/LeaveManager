using LeaveManager.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveManagment.Models
{
    public class LeaveAllocationModel
    {
        public int Id { get; set; }
        public int leaveTypeId { get; set; }
        public string EmployeeId { get; set; }
        public int NumberOfDays { get; set; }
        public int Year { get; set; }
    }
    public class CreateAlocationViewModel
    {
        public List<LeaveTypeModel> leaveTypeManager { get; set; }
    }


    public class DetailsLeaveAllocationViewModel {
        public EmployeesModel employeeModel { get; set; }
        public string EmployeeId { get; set; }
        public List<LeaveAllocationModel> allocationList { get; set; }
    }

}
