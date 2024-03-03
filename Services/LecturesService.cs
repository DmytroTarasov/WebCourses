using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess;
using DataAccess.Abstract;
using EntityDTO.Course_Structure;
using Services.Abstract;

namespace Services
{
    public class LecturesService: GenericService<LectureDto, int>
    {
        
        public async Task<IEnumerable<LectureDto>> GetByTopicId(int topicId)
        {
            return await _repository.GetAll(lecture => lecture.TopicId == topicId);
        }
        
        public async Task<LectureDto> GetByTopicId(int topicId, int id)
        {
            return await _repository.Get(l => l.Id == id && l.TopicId == topicId);
        }

        public LecturesService(IRepository<LectureDto, int> repository) : base(repository)
        {
        }
    }
}