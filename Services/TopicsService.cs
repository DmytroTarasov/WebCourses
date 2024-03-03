using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess;
using DataAccess.Abstract;
using EntityDTO.Course_Structure;
using Services.Abstract;

namespace Services
{
    public class TopicsService: GenericService<TopicDto, int>
    {
        public async Task<IEnumerable<TopicDto>> GetByUnitId(int unitId)
        {
            return await _repository.GetAll(topic => topic.UnitId == unitId);
        }
        
        public async Task<TopicDto> GetByUnitId(int unitId, int id)
        {
            return await _repository.Get(t => t.Id == id && t.UnitId == unitId);
        }

        public TopicsService(IRepository<TopicDto, int> repository) : base(repository)
        {
        }
    }
}