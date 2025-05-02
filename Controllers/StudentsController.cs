///*using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using CourseRegistrationApp.Data.Infrastructure;
//using CourseRegistrationApp.Models;
//using CourseRegistrationApp.Services.Interfaces;
//using CourseRegistrationApp.Models.ViewModels;

//namespace CourseRegistrationApp.Controllers
//{
//    public class StudentsController : Controller
//    {
//        private readonly IStudentService _studentService;

//        public StudentsController(IStudentService studentService)
//        {
//            _studentService = studentService;
//        }

//        // GET: Students
//        public async Task<IActionResult> Index()
//        {
//            return View(await _studentService.GetAllAsync());
//        }

//        // GET: Students/Details/5
//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var student = await _studentService.GetDetailsAsync(id);
//            if (student == null)
//            {
//                return NotFound();
//            }

//            return View(student);
//        }

//        // GET: Students/Create
//        public IActionResult Create()
//        {
//            return View();
//        }

//        // POST: Students/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create(StudentViewModel student)
//        {
//            if (ModelState.IsValid)
//            {
//                await _studentService.CreateAsync(student);
//                return RedirectToAction(nameof(Index));
//            }
//            return View(student);
//        }

//        // GET: Students/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var student = await _studentService.GetDetailsAsync(id);
//            if (student == null)
//            {
//                return NotFound();
//            }
//            return View(student);
//        }

//        // POST: Students/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, StudentViewModel student)
//        {
//            if (id != student.Id)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    await _studentService.UpdateAsync(id, student);
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!StudentExists(student.Id))
//                    {
//                        return NotFound();
//                    }
//                    else
//                    {
//                        throw;
//                    }
//                }
//                return RedirectToAction(nameof(Index));
//            }
//            return View(student);
//        }

//        // GET: Students/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var student = await _studentService.GetDetailsAsync(id);
//            if (student == null)
//            {
//                return NotFound();
//            }

//            return View(student);
//        }

//        // POST: Students/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            var student = await _studentService.GetDetailsAsync(id);
//            if (student == null) {
//                return NotFound();
//            }
//            await _studentService.DeleteAsync(id);
//            return RedirectToAction(nameof(Index));
//        }

//        private bool StudentExists(int id)
//        {
//            return _studentService.StudentExists(id);
//        }
//    }
//}
//*/