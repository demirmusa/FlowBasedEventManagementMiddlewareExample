using AutoMapper;
using CMS.BLL.StudentCourseScoreBusiness.Dto;
using CMS.DAL;
using CMS.DAL.DbEntities;
using EFCore.GenericRepository.GenericServices;
using EFCore.GenericRepository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS.BLL.EMEvents;
using EventManager.Core.Interfaces;

namespace CMS.BLL.StudentCourseScoreBusiness
{
    public class StudentCourseScoreService : GenericAsyncService<CourseServiceDbContext, StudentCourseScore, StudentCourseScoreDto>
    {
        private readonly IEMPublisher _eventPublisher;

        public StudentCourseScoreService(
            IGenericRepository<CourseServiceDbContext, StudentCourseScore> genericRepo,
            IMapper mapper,
            IEMPublisher eventPublisher) : base(genericRepo, mapper)
        {
            _eventPublisher = eventPublisher;
        }

        public async Task<List<StudentCourseScoreListDto>> Get(int studentId, int courseId)
        {
            return await base._genericRepo.AsQueryable(true).Where(x => x.FKStudentID == studentId && x.FKCourseID == courseId)
                .Select(x => new StudentCourseScoreListDto
                {
                    ID = x.ID,
                    Score = x.Score,
                    Deleted = x.Deleted,
                    FKPreviousVersionID = x.FKPreviousVersionID
                })
                .ToListAsync();
        }
        public override async Task<StudentCourseScoreDto> Insert(StudentCourseScoreDto entityDto)
        {
            var entity = base._mapper.Map<StudentCourseScore>(entityDto);

            if (await base._genericRepo.AsQueryable().AnyAsync(x => x.FKStudentID == entity.FKStudentID && x.FKCourseID == entity.FKCourseID))
                await base._genericRepo.DeleteAsync(x => x.FKStudentID == entity.FKStudentID && x.FKCourseID == entity.FKCourseID);

            var result = await base.Insert(entityDto);
            try
            {
                await _eventPublisher.PublishAsync(new EventStudentCourseScoreInserted()
                {
                    FKCourseId = result.FKCourseID,
                    FKStudentId = result.FKStudentID,
                    Score = result.Score,
                    StudentCourseScoreId = result.ID,
                    User = "GetAuthorizedUser"
                });
            }
            catch (Exception e)
            {
                //TODO: log
                throw new Exception("Inserting is done but an error occurred while publishing event.See inner exception for more information", e);
            }
            return result;
        }

        public override async Task<StudentCourseScoreDto> Delete(int id)
        {
            var result = await base.Delete(id);
            if (result == null) return null;//if there is no entity with given id it will return null
            try
            {
                await _eventPublisher.PublishAsync(new EventStudentCourseScoreDeleted()
                {
                    FKCourseId = result.FKCourseID,
                    FKStudentId = result.FKStudentID,
                    Score = result.Score,
                    StudentCourseScoreId = result.ID,
                    User = "GetAuthorizedUser"
                });
            }
            catch (Exception e)
            {
                //TODO: log
                throw new Exception("Deleting is done but an error occurred while publishing event.See inner exception for more information", e);
            }
            return result;
        }

        public override async Task<StudentCourseScoreDto> Delete(StudentCourseScoreDto entity)
        {
            var result = await base.Delete(entity);
            if (result == null) return null;
            try
            {
                await _eventPublisher.PublishAsync(new EventStudentCourseScoreDeleted()
                {
                    FKCourseId = result.FKCourseID,
                    FKStudentId = result.FKStudentID,
                    Score = result.Score,
                    StudentCourseScoreId = result.ID,
                    User = "GetAuthorizedUser"
                });
            }
            catch (Exception e)
            {
                //TODO: log
                throw new Exception("Deleting is done but an error occurred while publishing event.See inner exception for more information", e);
            }
            return result;
        }

        public override async Task<StudentCourseScoreDto> Update(StudentCourseScoreDto entityDto)
        {
            throw new NotImplementedException();
        }

    }
}
