using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using EntityDTO.Abstract;

namespace EntityDTO.Course_Structure
{
    public class TopicDto: EntityDtoBase
    {
        public int UnitId { get; set; }
        [JsonIgnore]
        public UnitDto Unit { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
    }
}