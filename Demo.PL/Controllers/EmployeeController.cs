using AutoMapper;
using Demo.BLL.Interfaces;
using Demo.BLL.Repositories;
using Demo.DAL.Models;
using Demo.PL.Helper;
using Demo.PL.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.Intrinsics.Arm;
using System.Threading.Tasks;

namespace Demo.PL.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        //private readonly IEmployeeRepository _employeeRepository;
        //private readonly IDepartmentRepository _UnitOfWork.DepartmentRepository;
        private readonly IUnitOfWork _UnitOfWork;

        //private readonly IMapper _mapper;
        public EmployeeController(/*IEmployeeRepository employeeRepository
            , IDepartmentRepository departmentRepository*/
            IUnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;
            //_employeeRepository = employeeRepository;
            //_UnitOfWork.DepartmentRepository = departmentRepository;

        }
        public async Task <IActionResult> Index(string SearchName)
        {

            //if (SearchName is null || SearchName == "")
            {
                var res = await _UnitOfWork.EmployeeRepository.GetAllAsync();
                return View(res);
            }
            //else
            //{
            //    var res = await _UnitOfWork.EmployeeRepository.SearchWithName(SearchName);
            //    return View(res); 
            //}
        }

        [HttpGet]
        public IActionResult Create()
        {
     
            ViewBag.Departments = _UnitOfWork.DepartmentRepository.GetAllAsync();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Employee Emp, IFormFile Image)    
        {
            //var MappedEmp=_mapper.Map<EmployeeViewModel,Employee>(EmpVM);
            if (Image is not null)
                Emp.ImageName = DocSetting.UploadFile(Image, "Image");
            if (ModelState.IsValid)
            {
                await  _UnitOfWork.EmployeeRepository.AddAsync(Emp);
                await _UnitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(Emp);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id , string ViewName="Edit")
        {
            ViewBag.Departments = await _UnitOfWork.DepartmentRepository.GetAllAsync();
            if (id is null)
                return BadRequest();
            var res = await _UnitOfWork.EmployeeRepository.GetByIdAsync(id.Value);

            if (res is null)
                return NotFound();
            return View(ViewName, res);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Employee Employee)
        {
            if (ModelState.IsValid)
            {
                //DocSetting.UploadFile(Employee.ImageName.Image);
                _UnitOfWork.EmployeeRepository.Update(Employee);
                await _UnitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(Employee);
        }

        public async Task<IActionResult> Details(int? id) {
           return await Edit(id, "Details");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            return await Edit(id, "Delete");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Employee employee)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _UnitOfWork.EmployeeRepository.Delete(employee);
                    int res = await _UnitOfWork.CompleteAsync();
                    if (res > 0 && employee.ImageName is not null )
                    {
                        DocSetting.DeleteFile(employee.ImageName, "Images");
                    }
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
