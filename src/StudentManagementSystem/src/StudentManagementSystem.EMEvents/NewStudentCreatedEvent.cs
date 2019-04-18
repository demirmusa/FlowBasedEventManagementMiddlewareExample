using EventManager.Core;
using EventManager.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagementSystem.BLL.StudentBusiness.Dto
{
    [EMEventInfo(eventName: "NewStudentCreatedEvent")]
    public class NewStudentCreatedEvent : IEMEvent
    {
        public string StudentNumber { get; set; }
        public int FKUserID { get; set; }
    }
}
