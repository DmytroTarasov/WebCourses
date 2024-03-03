using EntityDTO.Course_Structure;
using Microsoft.AspNetCore.Mvc;
using Services.Abstract;
using WebCourses.Controllers.Abstract;

namespace WebCourses.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseCategoriesController: GenericController<CourseCategoryDto, string>
    {
        public CourseCategoriesController(IService<CourseCategoryDto, string> service) : base(service)
        {
        }
    }
}