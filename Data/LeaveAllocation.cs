using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveManager.Data
{
    public class LeaveAllocation
    {
        [Key]
        public int Id { get; set; }
        public LeaveTypeManager leaveType { get; set; }
        [ForeignKey("leaveTypeId")]
        public int leaveTypeId { get; set; }
        public Employees Employee { get; set; }
        [ForeignKey("EmployeeId")]
        public string EmployeeId { get; set; }

        public int NumberOfDays { get; set; }
        public int Year { get; set; }

    }
}
