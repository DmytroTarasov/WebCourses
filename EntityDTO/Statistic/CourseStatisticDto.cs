using System;
using EntityDTO.Abstract;
using EntityDTO.Course_Structure;
using EntityDTO.Users;
using System.Text.Json.Serialization;

namespace EntityDTO.Statistic
{
    public class CourseStatisticDto: EntityDtoBase
    {
        public int CourseId { get; set; }
        [JsonIgnore]
        public CourseDto Course { get; set; }
        public int UserId { get; set; }
        [JsonIgnore]
        public StudentDto Student { get; set; }

        public bool IsFinished { get; set; }
    }
}