using System;
using System.Text.Json.Serialization;
using EntityDTO.Abstract;
using EntityDTO.Activities;
using EntityDTO.Course_Structure;
using EntityDTO.Users;

namespace EntityDTO.Statistic
{
    public class TopicQuizStatisticDto: EntityDtoBase
    {
        public int TopicStatisticId { get; set; }
        [JsonIgnore]
        public TopicStatisticDto TopicStatistic { get; set; }
        public int QuizId { get; set; }
        [JsonIgnore]
        public QuizDto Quiz { get; set; }

        public bool IsCorrect { get; set; }
        public bool IsFinished { get; set; }
    }
}