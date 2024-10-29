using Demo.BLL.Interfaces;
using Demo.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Intrinsics.Arm;

namespace Demo.PL.Controllers
{
    public class DepartmentController : Controller
    {


        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public IActionResult Index()
        {
            var departments = _departmentRepository.GetAll();
            return View(departments);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                _departmentRepository.Add(department);
                return RedirectToAction(nameof(Index));
            }
            return View(department);
        }

        public IActionResult Details(int? id, string ViewName="Details")
        {
            if (id is null)
                return BadRequest();
            var res = _departmentRepository.GetById(id.Value);

            if (res is null)
                return NotFound();

            return View(ViewName,res);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            ///if (id is null)
            ///    return BadRequest();
            ///var res = _departmentRepository.GetById(id.Value);
            ///if (res is null)
            ///    return NotFound();

            return Details(id,"Edit");

        }

        [HttpPost]
        public IActionResult Edit(Department Dep)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _departmentRepository.Update(Dep);
                    return RedirectToAction(nameof(Index));
                }
                catch (System.Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }

            }
            return View(Dep);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            return Details(id, "Delete");

        }
        [HttpPost]
        public IActionResult Delete(Department Dep)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _departmentRepository.Delete(Dep);
                    return RedirectToAction(nameof(Index));
                }
                catch (System.Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }

            }
            return View(Dep);
        }


    }
}