using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess;
using DataAccess.Abstract;
using EntityDTO.Course_Structure;
using Microsoft.AspNetCore.Mvc;
using Services.Abstract;

namespace Services
{
    public class UnitsService: GenericService<UnitDto, int>
    {
        public  async Task<IEnumerable<UnitDto>> GetByCourseId(int courseId)
        {
            return await _repository.GetAll(unit => unit.CourseId == courseId);
        }
        
        public  async Task<UnitDto> GetByCourseId(int courseId, int id)
        {
            return await _repository.Get(u => u.CourseId == courseId && u.Id == id);
        }

        public UnitsService(IRepository<UnitDto, int> repository) : base(repository)
        {
        }
    }
}