using System;
using System.ComponentModel.DataAnnotations.Schema;
using EntityDTO.Abstract;
using EntityDTO.Activities;
using EntityDTO.Course_Structure;
using EntityDTO.Users;
using System.Text.Json.Serialization;

namespace EntityDTO.Statistic
{
    public class ActivityQuizStatisticDto: EntityDtoBase
    {
        public int ActivityStatisticId { get; set; }
        [JsonIgnore]
        public ActivityStatisticDto ActivityStatistic { get; set; }
        public int QuizId { get; set; }
        [JsonIgnore]
        public QuizDto Quiz { get; set; }

        public bool IsCorrect { get; set; }
        public bool IsFinished { get; set; }
    }
}