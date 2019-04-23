using EFCore.GenericRepository;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMS.DAL.DbEntities
{
    public class StudentCourseJunction : BaseDbEntity
    {
        public int FKStudentID { get; set; }
        public int FKCourseID { get; set; }
        [ForeignKey("FKCourseID ")]
        public virtual CourseInformation CourseInformation { get; set; }
    }
}
