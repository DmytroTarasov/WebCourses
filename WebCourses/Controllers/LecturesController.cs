using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess;
using EntityDTO.Course_Structure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services;
using Services.Abstract;
using WebCourses.Authentication;
using WebCourses.Controllers.Abstract;

namespace WebCourses.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LecturesController: GenericController<LectureDto, int>
    {
        private readonly LecturesService _service;
        
        public LecturesController(LecturesService service) : base(service)
        {
            _service = service;
        }
        
        [HttpGet]
        [Route("~/api/Topics/{topicId}/[controller]")]
        public async Task<IEnumerable<LectureDto>> GetByTopicId(int topicId)
        {
            return await _service.GetByTopicId(topicId);
        }
        
        [HttpGet]
        [Route("~/api/Topics/{topicId}/[controller]/{id}")]
        public async Task<ActionResult<LectureDto>> GetByTopicId(int topicId, int id)
        {
            var lecture = await _service.GetByTopicId(topicId, id);
            if (lecture == null)
                return NotFound();
            return new ObjectResult(lecture);

        }
        [HttpPost]
        [Authorize(Roles = Roles.Professor)]
        public override ActionResult<LectureDto> Post(LectureDto entity)
        {
            return base.Post(entity);
        }
    }
}
