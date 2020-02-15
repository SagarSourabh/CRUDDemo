using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CRUDDemo.Models;

namespace CRUDDemo.Controllers
{
    public class EmpController : Controller
    {
        private readonly ApplicationDBContext _DbContext;
        public EmpController(ApplicationDBContext DB)
        {
            _DbContext = DB;
        }
        public IActionResult Index()
        {
            var employeelist = _DbContext.TblEmployee.ToList();
            return View(employeelist);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeModel model)
        {
            if (ModelState.IsValid)
            {
                _DbContext.Add(model);
                _DbContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int empID)
        {
            EmployeeModel model = new EmployeeModel();

            var employee = _DbContext.TblEmployee.Where(i => i.EmployeeID == empID).FirstOrDefault();
            if (employee != null)
            {
                model.EmployeeID = empID;
                model.EmployeeName = employee.EmployeeName;
                model.EmployeeEmail = employee.EmployeeEmail;
                model.EmployeeAge = employee.EmployeeAge;
                model.EmployeeSalary = employee.EmployeeSalary;
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EmployeeModel model)
        {
            if(ModelState.IsValid)
            {
                var employee = _DbContext.TblEmployee.Where(i => i.EmployeeID == model.EmployeeID).FirstOrDefault();

                employee.EmployeeName = model.EmployeeName;
                employee.EmployeeEmail = model.EmployeeEmail;
                employee.EmployeeAge = model.EmployeeAge;
                employee.EmployeeSalary = model.EmployeeSalary;
                _DbContext.Update(employee);
                await _DbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return View();
  
        }
    }
}