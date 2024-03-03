using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess;
using EntityDTO.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;
using Services.Abstract;
using WebCourses.Controllers.Abstract;

namespace WebCourses.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessorsController: GenericController<ProfessorDto, int>
    {
        private readonly ProfessorsService _service;
        public ProfessorsController(ProfessorsService service) : base(service)
        {
            _service = service;
        }
        
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<ActionResult<StudentDto>> Authenticate([FromBody]AuthenticationModel model)
        {
            var user = await _service.Authenticate(model.Email, model.Password);
            
            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }
        
        [HttpGet("filter")]
        public async Task<IEnumerable<ProfessorDto>> Filter([FromQuery] int courseId = -1)
        {
            if (courseId < 0)
                return new List<ProfessorDto>();
            return await _service.GetByCourseId(courseId);
        }
    }
}