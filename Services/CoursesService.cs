using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Abstract;
using EntityDTO.Course_Structure;
using Microsoft.AspNetCore.Mvc;
using Services.Abstract;

namespace Services
{
    public class CoursesService: GenericService<CourseDto, int>
    {
        public CoursesService(IRepository<CourseDto, int> repository) : base(repository)
        {
        }
        
        public async Task<IEnumerable<CourseDto>> GetAllByCategory(string category)
        {
            return await _repository.GetAll(c => c.Category.Id == category);
        }

        public async Task<IEnumerable<CourseDto>> GetMostPopular()
        {
            //TODO Write complex logic
            return (await _repository.GetN(3)).OrderBy(c => c.Name);
        }

        public async Task<CourseDto> GetWithAuthors(int courseId)
        {
            return await _repository.GetInclude(c => c.Authors, courseId);
        }
    }
}