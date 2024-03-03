using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using EntityDTO.Abstract;


namespace EntityDTO.Course_Structure
{
    public class ActivityDto: EntityDtoBase
    {
        public string ActivityTypeId { get; set; }
        [JsonIgnore]
        public ActivityTypeDto ActivityType { get; set; }
        public int TopicId { get; set; }
        [JsonIgnore]
        public TopicDto Topic { get; set; }
        
        public string Name { get; set; }
        public int TasksAmount { get; set; }
    }
}