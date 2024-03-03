using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
using EntityDTO.Abstract;

namespace EntityDTO.Users
{
    public class NotificationDto: EntityDtoBase
    {
        public int UserId { get; set; }
        [JsonIgnore]
        public StudentDto Student { get; set; }
        [AllowNull]
        public int BadgeId { get; set; }
        [JsonIgnore]
        public BadgeDto Badge { get; set; }
        
        public string Name { get; set; }
        public string Description { get; set; }
        
    }
}