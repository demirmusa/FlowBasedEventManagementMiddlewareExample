using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Example.CoreShareds;
using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.BLL.Courses.Interfaces;
using StudentManagementSystem.BLL.StudentSearch.interfaces;
using StudentManagementSystem.WebUI.Controllers;

namespace StudentManagementSystem.WebUI.Areas.Management.Controllers
{
    [Area("Management")]
    public class StudentCourseManagementController : SMSBaseController
    {
        private readonly ICourseManagementService _courseManagement;

        public StudentCourseManagementController(ICourseManagementService courseManagement)
        {
            _courseManagement = courseManagement;
        }
        public async Task<IActionResult> Index()
        {
            if (!IsStudentSelected)
                return RedirectToAction("Index", "Home", new { Area = "" });
            ViewBag.StudentName = SelectedStudent.Name + " " + SelectedStudent.Surname;
            var list = await _courseManagement.GetAllCourse();
            return View(list);
        }

        public async Task<IActionResult> AddCourseToStudent(int courseId)
        {
            if (!IsStudentSelected)
                return RedirectToAction("Index", "Home", new { Area = "" });

            var result = await _courseManagement.AddCourseToStudent(SelectedStudent.ID, courseId);
            if (!result.IsSucceed)
                return View("GenericResultView", result.ConvertTo(result.GetAllMessage()));
            return RedirectToAction(nameof(Index));
        }
    }
}