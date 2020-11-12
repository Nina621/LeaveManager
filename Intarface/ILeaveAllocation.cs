using LeaveManager.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveManagment.Intarface
{
     public interface ILeaveAllocation : IBase <LeaveAllocation>
    {
        public bool checkAllocation(string EmployeeId, int leaveTypeId);
        public ICollection<LeaveAllocation> getAllocationByEmployee(string id);
    }
}
