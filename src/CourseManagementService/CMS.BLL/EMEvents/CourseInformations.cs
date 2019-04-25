using System;
using System.Collections.Generic;
using System.Text;
using EventManager.Core;
using EventManager.Shared.Interfaces;

namespace CMS.BLL.EMEvents
{
    public class EventCourseCreated : IEMEvent
    {
        public int ID { get; set; }
        public string CourseTitle { get; set; }
        public string CourseDescription { get; set; }
        public int FKTeacherID { get; set; }
    }

    [EMEventInfo(eventName: "EventCourseDeleted")]
    public class EventCourseDeleted : EventCourseCreated
    {

    }
    [EMEventInfo(eventName: "EventCourseUpdated")]
    public class EventCourseUpdated : EventCourseCreated
    {

    }
}
