using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess;
using EntityDTO.Course_Structure;
using EntityDTO.Users;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Abstract;
using WebCourses.Controllers.Abstract;

namespace WebCourses.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoursesController: GenericController<CourseDto, int>
    {
        private readonly CoursesService _service;
        public CoursesController(CoursesService service) : base(service)
        {
            _service = service;
        }
        
        [HttpGet("filter")]
        public async Task<IEnumerable<CourseDto>> Get([FromQuery] string category = "",
            [FromQuery] bool popular = false)
        {
            if (popular)
                return await _service.GetMostPopular();
            if (!string.IsNullOrEmpty(category))
                return await _service.GetAllByCategory(category);
            return await _service.GetAll();
        }
    }
}