﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Example.CoreShareds;
using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Business.StudentSearch.interfaces;
using StudentManagementSystem.WebUI.Models;

namespace StudentManagementSystem.WebUI.Controllers
{
    public class HomeController : SMSBaseController
    {
        IStudentSearchBL _studentSearchBL;
        public HomeController(IStudentSearchBL studentSearchBL)
        {
            _studentSearchBL = studentSearchBL;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<GenericResult<List<(int id, string name)>>> Search(string query)
        {
            var searchResult = await _studentSearchBL.SearchStudent(query);

            return searchResult.GetUserSafeResult();
        }
        public async Task<GenericResult<bool>> SelectStudent(int id)
        {
            var searchResult = await _studentSearchBL.GetStudentInformationById(id);
            if (searchResult.IsSucceed)
                return GenericResult<bool>.Success(true);
            else
            {
                var result = searchResult.GetUserSafeResult();
                return GenericResult<bool>.UserSafeError(false, message: result.GetAllMessage());
            }
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
