using AutoMapper;
using Demo.BLL.Interfaces;
using Demo.BLL.Repositories;
using Demo.DAL.Models;
using Demo.PL.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.Intrinsics.Arm;

namespace Demo.PL.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IDepartmentRepository _departmentRepository;
        //private readonly IMapper _mapper;
        public EmployeeController(IEmployeeRepository employeeRepository
            , IDepartmentRepository departmentRepository)
        {
            _employeeRepository = employeeRepository;
            _departmentRepository = departmentRepository;

        }
        public IActionResult Index(string SearchName)
        {

            if (SearchName is null || SearchName == "")
            {
                var _Departments = _employeeRepository.GetAll();
                return View(_Departments);
            }
            else
            {
                var res = _employeeRepository.SearchWithName(SearchName);
                return View(res); 
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
     
            ViewBag.Departments = _departmentRepository.GetAll();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee Emp)    
        {
            //var MappedEmp=_mapper.Map<EmployeeViewModel,Employee>(EmpVM);

            if (ModelState.IsValid)
            {
                _employeeRepository.Add(Emp);
                return RedirectToAction(nameof(Index));
            }
            return View(Emp);
        }

        [HttpGet]
        public IActionResult Edit(int? id , string ViewName="Edit")
        {
            ViewBag.Departments = _departmentRepository.GetAll();
            if (id is null)
                return BadRequest();
            var res = _employeeRepository.GetById(id.Value);

            if (res is null)
                return NotFound();
            return View(ViewName, res);
        }

        [HttpPost]
        public IActionResult Edit(Employee Employee)
        {
            if (ModelState.IsValid)
            {
                _employeeRepository.Update(Employee);
                return RedirectToAction(nameof(Index));
            }
            return View(Employee);
        }

        public IActionResult Details(int? id) {
           return Edit(id, "Details");
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            return Edit(id, "Delete");
        }

        [HttpPost]
        public IActionResult Delete(Employee employee)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _employeeRepository.Delete(employee);
                    return RedirectToAction(nameof(Index));
                }
                catch (System.Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }

            }
            return View(employee);

        }

    }
}
