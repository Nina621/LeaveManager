using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LeaveManager.Data;
using LeaveManagment.Intarface;
using LeaveManagment.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LeaveManagment.Controllers
{
    public class LeaveAllocationController : Controller
    {
        private readonly ILeaveType _repository;
        private readonly ILeaveAllocation _repo;
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser> _userManager;

        public LeaveAllocationController(ILeaveType repository, IMapper mapper, UserManager<IdentityUser> um, ILeaveAllocation repo)
        {
            _repository = repository;
            _mapper = mapper;
            _userManager = um;
            _repo = repo;
            
        }

        public ActionResult Index()
        {
            var listLeaveTypes = _repository.FindAll().ToList();
            var model = _mapper.Map<List<LeaveTypeManager>, List<LeaveTypeModel>>(listLeaveTypes);

            CreateAlocationViewModel modelView = new CreateAlocationViewModel
            {
                leaveTypeManager = model
            };

            return View(modelView);
        }

        public ActionResult AllocateToEmployees(int id)
        {
            var leaveType = _repository.FindById(id);
            var employees = _userManager.GetUsersInRoleAsync("Employee").Result;

            foreach (var emp in employees)
            {

                LeaveAllocationModel model = new LeaveAllocationModel
                {
                    leaveTypeId = leaveType.Id,
                    EmployeeId = emp.Id,
                    NumberOfDays = leaveType.NumberOfDays,
                    Year = DateTime.Now.Year
                 
                };
                var model2 = model; 
                var leaveAllocationCreate = _mapper.Map<LeaveAllocation>(model2);
                _repo.Create(leaveAllocationCreate);

            }

            return RedirectToAction(nameof(Index));


        }

        public ActionResult GetEmployees() {

            //dohvati iz baze
            var listEmployees = _userManager.GetUsersInRoleAsync("Employee").Result;

            var model = _mapper.Map<List<EmployeesModel>>(listEmployees);

            return View(model);


        }

        public ActionResult Details(string id)
        {
            var employee = _userManager.FindByIdAsync(id).Result;
            var model = _mapper.Map<EmployeesModel>(employee);

            var allocationList = _repo.getAllocationByEmployee(id);
          //  var allocationListModel = _mapper.Map<List<LeaveAllocationModel>>(allocationList);

            DetailsLeaveAllocationViewModel detailsModel = new DetailsLeaveAllocationViewModel
            {
                employeeModel = model,
              
            };
           
            return View(detailsModel);

        }

    }
}