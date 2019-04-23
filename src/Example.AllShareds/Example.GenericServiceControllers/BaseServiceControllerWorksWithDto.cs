using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EFCore.GenericRepository.GenericServices;
using EFCore.GenericRepository.interfaces;
using Example.CoreShareds;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Example.GenericServiceControllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public abstract class BaseServiceController<Service, TContext, TEntity, TEntityDto> : ControllerBase
        where TContext : DbContext
        where Service : GenericAsyncService<TContext, TEntity, TEntityDto>
        where TEntity : class, IBaseDbEntity
        where TEntityDto : class

    {
        protected readonly Service _service;

        public BaseServiceController(Service service)
        {
            this._service = service;
        }
        [HttpGet("{id}")]
        public virtual async Task<ActionResult<GenericResult<TEntityDto>>> Get(int id)
        {
            try
            {
                var result = await _service.Get(id);
                return GenericResult<TEntityDto>.Success(result);
            }
            catch (Exception e)
            {
                //TODO: add log
                return GenericResult<TEntityDto>.UserSafeError("An error occurred");
            }
        }
        [HttpGet]
        public virtual async Task<ActionResult<GenericResult<List<TEntityDto>>>> Get()
        {
            try
            {
                var result = await _service.Get();
                return GenericResult<List<TEntityDto>>.Success(result);
            }
            catch (Exception e)
            {
                //TODO: add log
                return GenericResult<List<TEntityDto>>.UserSafeError("An error occurred");
            }
        }

        [HttpPost]
        public virtual async Task<ActionResult<GenericResult<TEntityDto>>> Insert(TEntityDto entityDto)
        {
            try
            {
                var result = await _service.Insert(entityDto);
                return GenericResult<TEntityDto>.Success(result);
            }
            catch (Exception e)
            {
                //TODO: add log
                return GenericResult<TEntityDto>.UserSafeError("An error occurred");
            }
        }

        [HttpPut]
        public virtual async Task<ActionResult<GenericResult<TEntityDto>>> Update(TEntityDto entityDto)
        {
            try
            {
                var result = await _service.Update(entityDto);
                return GenericResult<TEntityDto>.Success(result);
            }
            catch (Exception e)
            {
                //TODO: add log
                return GenericResult<TEntityDto>.UserSafeError("An error occurred");
            }
        }

        [HttpDelete("{id}")]
        public virtual async Task<ActionResult<GenericResult<TEntityDto>>> Delete(int id)
        {
            try
            {
                var result = await _service.Delete(id);
                return GenericResult<TEntityDto>.Success(result);
            }
            catch (Exception e)
            {
                //TODO: add log
                return GenericResult<TEntityDto>.UserSafeError("An error occurred");
            }
        }
    }

}
