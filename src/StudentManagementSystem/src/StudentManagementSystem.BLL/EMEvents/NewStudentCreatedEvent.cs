using System;
using System.Collections.Generic;
using System.Text;
using EventManager.Core;
using EventManager.Shared.Interfaces;

namespace StudentManagementSystem.BLL.EMEvents
{
    [EMEventInfo(eventName: "NewStudentCreatedEvent")]
    public class NewStudentCreatedEvent : IEMEvent
    {
        public string StudentNumber { get; set; }
        public int FKUserID { get; set; }
    }
}
