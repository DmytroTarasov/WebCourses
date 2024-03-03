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
    public class UnitsController: GenericController<UnitDto, int>
    {
        private readonly UnitsService _service;
        public UnitsController(UnitsService service) : base(service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("~/api/Courses/{courseId}/[controller]")]
        public  async Task<IEnumerable<UnitDto>> GetByCourseId(int courseId)
        {
            return await _service.GetByCourseId(courseId);
        }
        
        [HttpGet]
        [Route("~/api/Courses/{courseId}/[controller]/{id}")]
        public  async Task<ActionResult<UnitDto>> GetByCourseId(int courseId, int id)
        {
            var unit = await _service.GetByCourseId(courseId, id);
            if (unit == null)
                return NotFound();
            return new ObjectResult(unit);
        }
    }
}