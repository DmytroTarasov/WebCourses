using System;
using System.ComponentModel.DataAnnotations.Schema;
using EntityDTO.Abstract;
using EntityDTO.Course_Structure;
using EntityDTO.Users;
using System.Text.Json.Serialization;

namespace EntityDTO.Statistic
{
    public class ActivityStatisticDto: EntityDtoBase
    {
        public int ActivityId { get; set; }
        [JsonIgnore]
        public ActivityDto Activity { get; set; }
        public int UserId { get; set; }
        [JsonIgnore]
        public StudentDto Student { get; set; }

        public bool IsFinished { get; set; }
    }
}