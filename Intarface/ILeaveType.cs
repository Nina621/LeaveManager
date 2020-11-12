using LeaveManager.Data;
using LeaveManagment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveManagment.Intarface
{
    public interface ILeaveType : IBase<LeaveTypeManager>
    {
        void Edit(LeaveTypeManager leaveTypeEdit);
    }
}
