using System;
using System.Collections.Generic;
using System.Text;
using EventManager.Core;
using EventManager.Shared.Interfaces;

namespace CMS.BLL.EMEvents
{
    public class EventStudentAddedToCourse: IEMEvent
    {
        public int FKStudentID { get; set; }
        public int FKCourseID { get; set; }
    }

    [EMEventInfo(eventName: "EventStudentRemovedFromCourse")]
    public class EventStudentRemovedFromCourse : EventStudentAddedToCourse
    {

    }
}
