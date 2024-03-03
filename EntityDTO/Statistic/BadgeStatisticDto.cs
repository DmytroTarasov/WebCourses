using System;
using System.ComponentModel.DataAnnotations.Schema;
using EntityDTO.Abstract;
using EntityDTO.Users;
using System.Text.Json.Serialization;

namespace EntityDTO.Statistic
{
    public class BadgeStatisticDto: EntityDtoBase
    {
        public int BadgeId { get; set; }
        [JsonIgnore]
        public BadgeDto Badge { get; set; }
        public int UserId { get; set; }
        [JsonIgnore]
        public StudentDto Student { get; set; }
    }
}