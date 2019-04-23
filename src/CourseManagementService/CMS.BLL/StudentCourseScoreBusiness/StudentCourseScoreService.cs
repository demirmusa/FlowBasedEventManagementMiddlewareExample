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

namespace CMS.BLL.StudentCourseScoreBusiness
{
    public class StudentCourseScoreService : GenericAsyncService<CourseServiceDbContext, StudentCourseScore, StudentCourseScoreDto>
    {
        public StudentCourseScoreService(IGenericRepository<CourseServiceDbContext, StudentCourseScore> genericRepo, IMapper mapper) : base(genericRepo, mapper)
        {
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

            return await base.Insert(entityDto);
        }
        public override async Task<StudentCourseScoreDto> Update(StudentCourseScoreDto entityDto)
        {
            throw new NotImplementedException();
        }        
        
    }
}
