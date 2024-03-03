using System;
using EntityDTO.Abstract;
using EntityDTO.Activities;
using EntityDTO.Course_Structure;
using EntityDTO.Users;
using System.Text.Json.Serialization;

namespace EntityDTO.Statistic
{
    public class CourseQuizStatisticDto: EntityDtoBase
    {
        public int CourseStatisticId { get; set; }
        [JsonIgnore]
        public CourseStatisticDto CourseStatistic { get; set; }
        public int QuizId { get; set; }
        [JsonIgnore]
        public QuizDto Quiz { get; set; }

        public bool IsCorrect { get; set; }
        public bool IsFinished { get; set; }
    }
}