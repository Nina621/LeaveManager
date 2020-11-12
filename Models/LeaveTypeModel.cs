using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveManagment.Models
{
    public class LeaveTypeModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
       
        [Display(Name ="Number of Days")]
        [Range(1,20,ErrorMessage ="Value must be between 1 to 20")]
        public int NumberOfDays { get; set; }
    }
}
