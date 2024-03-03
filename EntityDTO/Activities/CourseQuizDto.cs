using System;
using EntityDTO.Abstract;
using EntityDTO.Course_Structure;
using System.Text.Json.Serialization;

namespace EntityDTO.Activities
{
    public class CourseQuizDto: EntityDtoBase
    {
        public int CourseId;
        [JsonIgnore]
        public CourseDto Course { get; set; }
        
        public int TasksAmount { get; set; }
    }
}