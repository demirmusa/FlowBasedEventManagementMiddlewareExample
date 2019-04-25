using System;
using System.Collections.Generic;
using System.Text;
using EventManager.Core;
using EventManager.Shared.Interfaces;

namespace CMS.BLL.EMEvents
{
    public class EventStudentCourseScoreInserted : IEMEvent
    {
        public int StudentCourseScoreId { get; set; }
        public int FKStudentId { get; set; }
        public int FKCourseId { get; set; }
        public double Score { get; set; }
        public string User { get; set; }
    }
    [EMEventInfo(eventName: "EventStudentCourseScoreDeleted")]
    public class EventStudentCourseScoreDeleted : EventStudentCourseScoreInserted
    {
    }
}
