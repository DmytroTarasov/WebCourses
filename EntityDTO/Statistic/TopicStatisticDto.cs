using System;
using System.Text.Json.Serialization;
using EntityDTO.Abstract;
using EntityDTO.Course_Structure;
using EntityDTO.Users;

namespace EntityDTO.Statistic
{
    public class TopicStatisticDto: EntityDtoBase
    {
        public int TopicId { get; set; }
        [JsonIgnore]
        public TopicDto Topic { get; set; }
        public int UserId { get; set; }
        [JsonIgnore]
        public StudentDto Student { get; set; }

        public bool IsFinished { get; set; }
    }
}