using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess;
using EntityDTO.Course_Structure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services;
using Services.Abstract;
using WebCourses.Controllers.Abstract;

namespace WebCourses.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TopicsController: GenericController<TopicDto, int>
    {
        private readonly TopicsService _service;
        
        public TopicsController(TopicsService service) : base(service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("~/api/Units/{unitId}/[controller]")]
        public async Task<IEnumerable<TopicDto>> GetByUnitId(int unitId)
        {
            return await _service.GetByUnitId(unitId);
        }
        
        [HttpGet]
        [Route("~/api/Units/{unitId}/[controller]/{id}")]
        public async Task<ActionResult<TopicDto>> GetByUnitId(int unitId, int id)
        {
            var topic = await _service.GetByUnitId(unitId, id);
            if (topic == null)
                return NotFound();
            return new ObjectResult(topic);

        }
    }
}
