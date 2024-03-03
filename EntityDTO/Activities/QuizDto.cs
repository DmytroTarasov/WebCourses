using System;
using System.ComponentModel.DataAnnotations.Schema;
using EntityDTO.Abstract;
using EntityDTO.Course_Structure;
using System.Text.Json.Serialization;

namespace EntityDTO.Activities
{
    public class QuizDto: EntityDtoBase
    {
        public int ActivityId { get; set; }
        [JsonIgnore]
        public ActivityDto Activity { get; set; }
        
        
        public string Question { get; set; }
        public int Points { get; set; }
    }
}