using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Business.StudentSearch.Dto;
using StudentManagementSystem.WebUI.Models;

namespace StudentManagementSystem.WebUI.Controllers
{
    public class SMSBaseController : Controller
    {
        private const string _sessionKey = "BaseController.Session.SelectedStudent";
        protected StudentSearchResultDto SelectedStudent
        {
            get
            {
                return HttpContext.Session.Get<StudentSearchResultDto>(_sessionKey);
            }
            private set
            {
                HttpContext.Session.Set(_sessionKey, value);
            }
        }
        protected bool IsStudentSelected { get { return SelectedStudent != null; } }

        protected void SetSelectedStudent(StudentSearchResultDto studentInfoModel)
        {
            SelectedStudent = studentInfoModel;
        }
        protected void ClearSelectedStudent()
        {
            SelectedStudent = null;
        }

    }
}