using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDDemo.Models
{
    public class EmployeeModel: IEntity
    {
        [Key]
        public int EmployeeID { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage ="Employee name is required")]
        public string EmployeeName { get; set; }

        [Display(Name ="Email")]
        [Required(ErrorMessage = "Employee email is required")]
        public string EmployeeEmail { get; set; }

        [Display(Name = "Age")]
        [Required(ErrorMessage = "Employee age is required")]
        [Range(22,58)]
        public int EmployeeAge { get; set; }

        [Display(Name = "Salary")]
        [Required(ErrorMessage = "Employee salary is required")]
        public decimal? EmployeeSalary { get; set; }
    }
}
