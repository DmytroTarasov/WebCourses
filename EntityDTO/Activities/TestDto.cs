using System;
using System.ComponentModel.DataAnnotations.Schema;
using EntityDTO.Abstract;
using EntityDTO.Course_Structure;
using System.Text.Json.Serialization;

namespace EntityDTO.Activities
{
    public class TestDto: EntityDtoBase
    {
        public int ActivityId { get; set; }
        [JsonIgnore]
        public ActivityDto Activity { get; set; }
        
        public string Name { get; set; }
        public int Points { get; set; }
        public string AssertionPath { get; set; }
    }
}