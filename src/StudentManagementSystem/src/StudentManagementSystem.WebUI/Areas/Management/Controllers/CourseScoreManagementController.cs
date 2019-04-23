using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Example.CoreShareds;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.BLL.Courses.Dto;
using StudentManagementSystem.BLL.Courses.Interfaces;
using StudentManagementSystem.WebUI.Controllers;

namespace StudentManagementSystem.WebUI.Areas.Management.Controllers
{
    [Area("Management")]
    public class CourseScoreManagementController : SMSBaseController
    {
        private readonly ICourseScoreManagementService _courseScoreManagementService;

        public CourseScoreManagementController(ICourseScoreManagementService courseScoreManagementService)
        {
            this._courseScoreManagementService = courseScoreManagementService;
        }
        public async Task<IActionResult> Index()
        {
            if (!base.IsStudentSelected)
                return RedirectToAction("Index", "Home", new { Area = "" });

            var courses = await _courseScoreManagementService.GetCoursesByStudentId(SelectedStudent.ID);

            return View(courses);
        }

        [HttpGet]
        public async Task<IActionResult> CourseScoresForStudent(int courseId)
        {
            var result = await _courseScoreManagementService.GetScoresByCourseAndStudentId(SelectedStudent.ID, courseId);
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> InsertScore(int courseId, string courseName)
        {
            ViewBag.CourseId = courseId;
            ViewBag.CourseName = courseName;
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> InsertScore(StudentCourseScoreDto dto)
        {
            dto.FKStudentID = SelectedStudent.ID;
            var result = await _courseScoreManagementService.InsertScore(dto);
            var userSafe = result.GetUserSafeResult();

            return Json(userSafe.ConvertTo(userSafe.GetAllMessage()));
        }

    }
}