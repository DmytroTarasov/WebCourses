using System;
using System.Threading.Tasks;
using DataAccess;
using EntityDTO.Course_Structure;
using EntityDTO.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Models;
using Services;
using Services.Abstract;
using WebCourses.Controllers.Abstract;

namespace WebCourses.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController: GenericController<StudentDto, int>
    {
        private readonly StudentsService _service;
        public StudentsController(StudentsService service) : base(service)
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
    }
}