using System.Collections.Generic;
using System.Threading.Tasks;
using EntityDTO.Course_Structure;
using Microsoft.AspNetCore.Mvc;
using Services;
using WebCourses.Controllers.Abstract;

namespace WebCourses.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ActivitiesController: GenericController<ActivityDto, int>
    {
        private readonly ActivitiesService _service;
        public ActivitiesController(ActivitiesService service) : base(service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("~/api/Topics/{topicId}/[controller]")]
        public async Task<IEnumerable<ActivityDto>> GetByTopicId(int topicId)
        {
            return await _service.GetByTopicId(topicId);
        }
        
        [HttpGet]
        [Route("~/api/Topics/{topicId}/[controller]/{id}")]
        public async Task<ActionResult<ActivityDto>> GetByTopicId(int topicId, int id)
        {
            var activity = await _service.GetByTopicId(topicId, id);
            if (activity == null)
                return NotFound();
            return new ObjectResult(activity);

        }
    }
}
