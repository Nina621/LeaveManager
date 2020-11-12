using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveManagment.Models
{
    public class EmployeesModel
    {
        public string Id;
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name ="Date Joined")]
        public DateTime DateJoined { get; set; }

    }
   
}
