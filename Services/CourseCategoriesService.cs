using DataAccess.Abstract;
using EntityDTO.Course_Structure;
using Services.Abstract;

namespace Services
{
    public class CourseCategoriesService: GenericService<CourseCategoryDto, string>
    {
        public CourseCategoriesService(IRepository<CourseCategoryDto, string> repository) : base(repository)
        {
        }
    }
}