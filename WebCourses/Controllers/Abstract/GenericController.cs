using System.Collections.Generic;
using System.Threading.Tasks;
using EntityDTO.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Services.Abstract;
using WebCourses.Authentication;

namespace WebCourses.Controllers.Abstract
{
    
    public abstract class GenericController<TEntity, TKey> : ControllerBase where TEntity : class, IEntity<TKey>
    {
        private readonly IService<TEntity, TKey> _service;
        
        protected GenericController(IService<TEntity, TKey> service)
        {
            _service = service;
        }
        
        [HttpGet]
        public virtual async Task<IEnumerable<TEntity>> Get()
        {
            return await _service.GetAll();
        }
        
        [HttpGet("{key}")]
        public virtual async Task<ActionResult<TEntity>> Get(TKey key)
        {
            var entity = await _service.Get(key);
            if (entity == null)
                return NotFound();
            return new ObjectResult(entity);
        }

        [HttpPost]
        // [Authorize(Roles = Roles.Professor)]
        public virtual ActionResult<TEntity> Post(TEntity entity)
        {
            if (entity == null)
                return BadRequest();
            _service.Add(entity);
            return Ok(entity);
        }

        [HttpPut]
        [Authorize(Roles = Roles.Student)]
        public virtual async Task<ActionResult<TEntity>> Put(TEntity entity)
        {
            if (entity == null)
                return BadRequest();
            if (await _service.Exists(entity.Id))
                return NotFound();
            _service.Replace(entity);
            return Ok(entity);
        }

        [HttpPatch("{key}")]
        // [Authorize(Roles = Roles.Student)]
        public virtual async Task<ActionResult<TEntity>> Patch(TKey key, 
            [FromBody] JsonPatchDocument<TEntity> patchDocument)
        {
            var entity = await _service.Get(key);
            if (entity== null)
                return NotFound();
            patchDocument.ApplyTo(entity);
            _service.Update(entity);
            return Ok(entity);
        }

        [HttpDelete("{key}")]
        [Authorize(Roles = Roles.Student)]
        public virtual async Task<ActionResult<TEntity>> Delete(TKey key)
        {
            if (await _service.Exists(key))
                return NotFound();
            _service.Remove(key);
            return Ok(key);
        }
    }
}