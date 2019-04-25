using System;
using CMS.BLL.CourseInformationBusiness.Dto;
using CMS.DAL;
using CMS.DAL.DbEntities;
using EFCore.GenericRepository.GenericServices;
using EFCore.GenericRepository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS.BLL.EMEvents;
using EventManager.Core.Interfaces;

namespace CMS.BLL.StudentCourseJunctionBusiness
{
    public class StudentCourseJunctionService : GenericAsyncService<CourseServiceDbContext, StudentCourseJunction>
    {
        private readonly IGenericRepository<CourseServiceDbContext, CourseInformation> _courseInformationRepo;
        private readonly IEMPublisher _eventPublisher;

        public StudentCourseJunctionService(
            IGenericRepository<CourseServiceDbContext, StudentCourseJunction> genericRepo,
            IGenericRepository<CourseServiceDbContext, CourseInformation> courseInformationRepo,
            IEMPublisher eventPublisher
            ) : base(genericRepo)
        {
            this._courseInformationRepo = courseInformationRepo;
            _eventPublisher = eventPublisher;
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

        public override async Task<StudentCourseJunction> Insert(StudentCourseJunction entity)
        {
            var result = await base.Insert(entity);
            try
            {
                await _eventPublisher.PublishAsync(new EventStudentAddedToCourse
                {
                    FKCourseID = result.FKCourseID,
                    FKStudentID = result.FKStudentID
                });
            }
            catch (Exception e)
            {
                //TODO: log
                throw new Exception("Inserting is done but an error occurred while publishing event.See inner exception for more information", e);
            }
            return result;
        }

        public override async Task<StudentCourseJunction> Delete(int id)
        {
            var result = await base.Delete(id);
            if (result == null) return null;//if there is no entity with given id it will return null
            try
            {
                await _eventPublisher.PublishAsync(new EventStudentRemovedFromCourse()
                {
                    FKCourseID = result.FKCourseID,
                    FKStudentID = result.FKStudentID
                });
            }
            catch (Exception e)
            {
                //TODO: log
                throw new Exception("Deleting is done but an error occurred while publishing event.See inner exception for more information", e);
            }
            return result;
        }

        public override async Task<StudentCourseJunction> Delete(StudentCourseJunction entity)
        {
            var result = await base.Delete(entity);
            if (result == null) return null;
            try
            {
                await _eventPublisher.PublishAsync(new EventStudentRemovedFromCourse()
                {
                    FKCourseID = result.FKCourseID,
                    FKStudentID = result.FKStudentID
                });
            }
            catch (Exception e)
            {
                //TODO: log
                throw new Exception("Deleting is done but an error occurred while publishing event.See inner exception for more information", e);
            }
            return result;
        }

        public override Task<StudentCourseJunction> Update(StudentCourseJunction entity)
        {
            throw new NotImplementedException("Update is not available for student courses. Add new or delete exists");
        }
    }
}
