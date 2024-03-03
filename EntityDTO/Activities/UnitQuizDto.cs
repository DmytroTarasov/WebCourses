using System;
using System.Text.Json.Serialization;
using EntityDTO.Abstract;
using EntityDTO.Course_Structure;

namespace EntityDTO.Activities
{
    public class UnitQuizDto: EntityDtoBase
    {
        public int UnitId;
        [JsonIgnore]
        public UnitDto Unit { get; set; }
        
        public int TasksAmount { get; set; }
    }
}