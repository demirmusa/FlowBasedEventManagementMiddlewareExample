using EventManager.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagementSystem.EMEvents
{
    public class StudentDeletedEvent: IEMEvent
    {
        public string StudentNumber { get; set; }
        public int FKUserID { get; set; }
    }
}
