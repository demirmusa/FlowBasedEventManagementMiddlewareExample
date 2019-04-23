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
    public abstract class BaseServiceController<Service, TContext, TEntity> : ControllerBase
        where TContext : DbContext
        where Service : GenericAsyncService<TContext, TEntity>
        where TEntity : class, IBaseDbEntity

    {
        protected readonly Service _service;

        public BaseServiceController(Service service)
        {
            this._service = service;
        }
        [HttpGet("{id}")]
        public virtual async Task<ActionResult<GenericResult<TEntity>>> Get(int id)
        {
            try
            {
                var result = await _service.Get(id);
                return GenericResult<TEntity>.Success(result);
            }
            catch (Exception e)
            {
                //TODO: add log
                return GenericResult<TEntity>.UserSafeError("An error occurred");
            }
        }
        [HttpGet]
        public virtual async Task<ActionResult<GenericResult<List<TEntity>>>> Get()
        {
            try
            {
                var result = await _service.Get();
                return GenericResult<List<TEntity>>.Success(result);
            }
            catch (Exception e)
            {
                //TODO: add log
                return GenericResult<List<TEntity>>.UserSafeError("An error occurred");
            }
        }

        [HttpPost]
        public virtual async Task<ActionResult<GenericResult<TEntity>>> Insert(TEntity entityDto)
        {
            try
            {
                var result = await _service.Insert(entityDto);
                return GenericResult<TEntity>.Success(result);
            }
            catch (Exception e)
            {
                //TODO: add log
                return GenericResult<TEntity>.UserSafeError("An error occurred");
            }
        }

        [HttpPut]
        public virtual async Task<ActionResult<GenericResult<TEntity>>> Update(TEntity entityDto)
        {
            try
            {
                var result = await _service.Update(entityDto);
                return GenericResult<TEntity>.Success(result);
            }
            catch (Exception e)
            {
                //TODO: add log
                return GenericResult<TEntity>.UserSafeError("An error occurred");
            }
        }

        [HttpDelete("{id}")]
        public virtual async Task<ActionResult<GenericResult<TEntity>>> Delete(int id)
        {
            try
            {
                var result = await _service.Delete(id);
                return GenericResult<TEntity>.Success(result);
            }
            catch (Exception e)
            {
                //TODO: add log
                return GenericResult<TEntity>.UserSafeError("An error occurred");
            }
        }
    }

}