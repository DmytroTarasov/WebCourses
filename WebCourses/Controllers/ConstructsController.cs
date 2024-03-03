using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess;
using EntityDTO.Course_Structure;
using EntityDTO.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services;
using Services.Abstract;
using WebCourses.Controllers.Abstract;

namespace WebCourses.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConstructsController: GenericController<LectureConstructDto, int>
    {
        private readonly ConstructsService _service;
        public ConstructsController(ConstructsService service) : base(service)
        {
            _service = service;
        }


        [HttpGet]
        [Route("~/api/Lectures/{lectureId}/[controller]")]
        public async Task<IEnumerable<LectureConstructDto>> GetByLectureId(int lectureId)
        {
            return await _service.GetByLectureId(lectureId);
        }
    }
}
