using System;
using System.Text.Json.Serialization;
using EntityDTO.Abstract;
using EntityDTO.Course_Structure;
using EntityDTO.Users;

namespace EntityDTO.Statistic
{
    public class UnitStatisticDto: EntityDtoBase
    {
        public int UnitId { get; set; }
        [JsonIgnore]
        public UnitDto Unit { get; set; }
        public int UserId { get; set; }
        [JsonIgnore]
        public StudentDto Student { get; set; }

        public bool IsFinished { get; set; }
    }
}