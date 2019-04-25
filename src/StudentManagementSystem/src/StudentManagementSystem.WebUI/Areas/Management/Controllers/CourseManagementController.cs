using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Example.CoreShareds;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.BLL.Courses.Dto;
using StudentManagementSystem.BLL.Courses.Interfaces;

namespace StudentManagementSystem.WebUI.Areas.Management.Controllers
{
    [Area("Management")]
    public class CourseManagementController : Controller
    {
        private readonly ICourseManagementService _courseManagement;

        public CourseManagementController(ICourseManagementService courseManagement)
        {
            _courseManagement = courseManagement;
        }
        public async Task<IActionResult> Index()
        {
            var allCourses = await _courseManagement.GetAllCourse();
            return View(allCourses);
        }
        public async Task<IActionResult> ListAllCourses()
        {
            var allCourses = await _courseManagement.GetAllCourse();
            return View(allCourses);
        }

        public async Task<IActionResult> AddOrUpdateCourse(int? id = null)
        {
            if (id.HasValue)
            {
                var course = await _courseManagement.GetCourse(id.Value);
                return View(course);
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<GenericResult<CourseInformationDto>>> AddOrUpdateCourse([Bind(Prefix = "Data")]CourseInformationDto dto)
        {
            if (dto.ID == 0)
                return await _courseManagement.InsertCourse(dto);

            return await _courseManagement.UpdateCourse(dto);
        }

        [HttpGet]
        public async Task<ActionResult<GenericResult<CourseInformationDto>>> Delete(int id)
        {
            return await _courseManagement.DeleteCourse(id);
        }
    }
}