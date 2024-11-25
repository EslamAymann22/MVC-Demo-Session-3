using Demo.BLL.Interfaces;
using Demo.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Intrinsics.Arm;
using System.Threading.Tasks;

namespace Demo.PL.Controllers
{
    [Authorize]
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

        public async Task<IActionResult> Index()
        {
            var departments = await _UnitOfWork.DepartmentRepository.GetAllAsync();
            return View(departments);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Department department)
        {
            if (ModelState.IsValid)
            {
                await _UnitOfWork.DepartmentRepository.AddAsync(department);
                await _UnitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(department);
        }

        public async Task<IActionResult> Details(int? id, string ViewName="Details")
        {
            if (id is null)
                return BadRequest();
            var res = await _UnitOfWork.DepartmentRepository.GetByIdAsync(id.Value);

            if (res is null)
                return NotFound();

            return View(ViewName,res);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            ///if (id is null)
            ///    return BadRequest();
            ///var res = _departmentRepository.GetById(id.Value);
            ///if (res is null)
            ///    return NotFound();

            return await Details(id,"Edit");

        }

        [HttpPost]
        public async Task<IActionResult> Edit(Department Dep)
        {
            if (ModelState.IsValid)
            {
                try
                {
                   _UnitOfWork.DepartmentRepository.Update(Dep);
                   await  _UnitOfWork.CompleteAsync();  

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
        public async Task<IActionResult> Delete(int? id)
        {
            return  await Details(id, "Delete");

        }
        [HttpPost]
        public async Task<IActionResult> Delete(Department Dep)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _UnitOfWork.DepartmentRepository.Delete(Dep);
                    await _UnitOfWork.CompleteAsync();
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