using Demo.BLL.Interfaces;
using Demo.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Intrinsics.Arm;

namespace Demo.PL.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IUnitOfWork _UnitOfWork;


        //private readonly IDepartmentRepository _departmentRepository;

        public DepartmentController(/*IDepartmentRepository departmentRepository*/
            IUnitOfWork unitOfWork)
        {
            //_departmentRepository = departmentRepository;
            _UnitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var departments = _UnitOfWork.DepartmentRepository.GetAll();
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
                _UnitOfWork.DepartmentRepository.Add(department);
                _UnitOfWork.Complete();
                return RedirectToAction(nameof(Index));
            }
            return View(department);
        }

        public IActionResult Details(int? id, string ViewName="Details")
        {
            if (id is null)
                return BadRequest();
            var res = _UnitOfWork.DepartmentRepository.GetById(id.Value);

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
                    _UnitOfWork.DepartmentRepository.Update(Dep);
                    _UnitOfWork.Complete();

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
                    _UnitOfWork.DepartmentRepository.Delete(Dep);
                    _UnitOfWork.Complete();
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