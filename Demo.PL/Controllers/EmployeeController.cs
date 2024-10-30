using Demo.BLL.Interfaces;
using Demo.BLL.Repositories;
using Demo.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.Intrinsics.Arm;

namespace Demo.PL.Controllers
{




    public class EmployeeController : Controller
    {
        IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public IActionResult Index()
        {
            var res = _employeeRepository.GetAll();
            //ViewBag.
            ViewData["message"] = "I'm from Index Controller";
            //ViewBag.Message = ViewData["Message"]  + "From ViewBag";
            ViewBag.Message = 5;
            return View(res);

        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee Emp)
        {
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
