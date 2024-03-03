using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess;
using DataAccess.Abstract;
using EntityDTO.Course_Structure;
using Services.Abstract;

namespace Services
{
    public class ActivitiesService: GenericService<ActivityDto, int>
    {

        
        public async Task<IEnumerable<ActivityDto>> GetByTopicId(int topicId)
        {
            return await _repository.GetAll(activity => activity.TopicId == topicId);
        }
        
        public async Task<ActivityDto> GetByTopicId(int topicId, int id)
        {
            return await _repository.Get(activity => activity.TopicId == topicId 
                                                     && activity.Id == id);
        }

        public ActivitiesService(IRepository<ActivityDto, int> repository) : base(repository)
        {
        }
    }
}