using CMS.BLL.CourseInformationBusiness.Dto;
using CMS.DAL;
using CMS.DAL.DbEntities;
using EFCore.GenericRepository.GenericServices;
using EFCore.GenericRepository.interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.BLL.StudentCourseJunctionBusiness
{
    public class StudentCourseJunctionService : GenericAsyncService<CourseServiceDbContext, StudentCourseJunction>
    {
        private readonly IGenericRepository<CourseServiceDbContext, CourseInformation> _courseInformationRepo;

        public StudentCourseJunctionService(IGenericRepository<CourseServiceDbContext, StudentCourseJunction> genericRepo,
            IGenericRepository<CourseServiceDbContext, CourseInformation> courseInformationRepo
            ) : base(genericRepo)
        {
            this._courseInformationRepo = courseInformationRepo;
        }
        public async Task<List<CourseInformationDto>> GetCoursesByStudentId(int studentId)
        {
            return await base._genericRepo.AsQueryable().Where(x => x.FKStudentID == studentId).Select(x => new CourseInformationDto
            {
                CourseDescription = x.CourseInformation.CourseDescription,
                CourseTitle = x.CourseInformation.CourseTitle,
                FKTeacherID = x.CourseInformation.FKTeacherID,
                ID = x.CourseInformation.ID
            }).ToListAsync();
        }
    }
}
