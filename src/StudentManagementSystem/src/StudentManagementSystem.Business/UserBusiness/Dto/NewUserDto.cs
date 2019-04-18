﻿using StudentManagementSystem.Business.People.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagementSystem.Business.UserBusiness.Dto
{
    public class NewUserDto
    {
        public int FKPersonID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public PersonDto PersonDto { get; set; }
    }
}
