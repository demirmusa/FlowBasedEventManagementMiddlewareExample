using CMS.DAL;
using EFCore.GenericRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using CMS.DAL.DbEntities;
using System.Threading.Tasks;
using EFCore.GenericRepository.GenericServices;
using CMS.BLL.CourseInformationBusiness.Dto;
using AutoMapper;
using CMS.BLL.EMEvents;
using EventManager.Core.Interfaces;
using Example.CoreShareds;

namespace CMS.BLL.CourseInformationBusiness
{
    public class CourseInformationService : GenericAsyncService<CourseServiceDbContext, CourseInformation, CourseInformationDto>
    {
        private readonly IEMPublisher _eventPublisher;

        public CourseInformationService(
            IGenericRepository<CourseServiceDbContext, CourseInformation> genericRepository,
            IMapper mapper,
            IEMPublisher eventPublisher
            )
            : base(genericRepository, mapper)
        {
            _eventPublisher = eventPublisher;
        }

        public override async Task<CourseInformationDto> Insert(CourseInformationDto entityDto)
        {
            var result = await base.Insert(entityDto);
            try
            {
                await _eventPublisher.PublishAsync(new EventCourseCreated()
                {
                    ID = result.ID,
                    CourseDescription = result.CourseDescription,
                    CourseTitle = result.CourseTitle,
                    FKTeacherID = result.FKTeacherID
                });
            }
            catch (Exception e)
            {
                //TODO: log
                throw new Exception("Deleting is done but an error occurred while publishing event.See inner exception for more information", e);
            }
            return result;
        }

        public override async Task<CourseInformationDto> Update(CourseInformationDto entityDto)
        {
            var result = await base.Update(entityDto);
            try
            {
                await _eventPublisher.PublishAsync(new EventCourseUpdated()
                {
                    ID = result.ID,
                    CourseDescription = result.CourseDescription,
                    CourseTitle = result.CourseTitle,
                    FKTeacherID = result.FKTeacherID
                });
            }
            catch (Exception e)
            {
                //TODO: log
                throw new Exception("Deleting is done but an error occurred while publishing event.See inner exception for more information", e);
            }
            return result;
        }

        public override async Task<CourseInformationDto> Delete(int id)
        {
            var result = await base.Delete(id);
            if (result == null) return null;//if there is no entity with given id it will return null
            try
            {
                await _eventPublisher.PublishAsync(new EventCourseDeleted()
                {
                    ID = result.ID,
                    CourseDescription = result.CourseDescription,
                    CourseTitle = result.CourseTitle,
                    FKTeacherID = result.FKTeacherID
                });
            }
            catch (Exception e)
            {
                //TODO: log
                throw new Exception("Deleting is done but an error occurred while publishing event.See inner exception for more information", e);
            }
            return result;
        }

        public override async Task<CourseInformationDto> Delete(CourseInformationDto entity)
        {
            var result = await base.Delete(entity);
            if (result == null) return null;
            try
            {
                await _eventPublisher.PublishAsync(new EventCourseDeleted()
                {
                    ID = result.ID,
                    CourseDescription = result.CourseDescription,
                    CourseTitle = result.CourseTitle,
                    FKTeacherID = result.FKTeacherID
                });
            }
            catch (Exception e)
            {
                //TODO: log
                throw new Exception("Deleting is done but an error occurred while publishing event.See inner exception for more information", e);
            }
            return result;
        }
    }
}
