using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using EntityDTO.Abstract;

namespace EntityDTO.Course_Structure
{
    public class UnitDto: EntityDtoBase
    {
        public int CourseId { get; set; }
        [JsonIgnore]
        public CourseDto Course { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
    }
}