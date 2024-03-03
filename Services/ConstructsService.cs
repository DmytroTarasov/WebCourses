using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess;
using DataAccess.Abstract;
using EntityDTO.Course_Structure;
using Services.Abstract;

namespace Services
{
    public class ConstructsService: GenericService<LectureConstructDto, int>
    {

        public async Task<IEnumerable<LectureConstructDto>> GetByLectureId(int lectureId)
        {
            return await _repository.GetAll(c => c.LectureId == lectureId);
        }

        public ConstructsService(IRepository<LectureConstructDto, int> repository) : base(repository)
        {
        }
    }
}