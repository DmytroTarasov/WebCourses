using System;
using EntityDTO.Abstract;
using EntityDTO.Course_Structure;
using System.Text.Json.Serialization;

namespace EntityDTO.Activities
{
    public class TopicQuizDto: EntityDtoBase
    {
        public int TopicId;
        [JsonIgnore]
        public TopicDto Topic { get; set; }
        
        public int TasksAmount { get; set; }
    }
}