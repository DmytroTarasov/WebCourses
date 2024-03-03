using System;
using System.ComponentModel.DataAnnotations.Schema;
using EntityDTO.Abstract;
using EntityDTO.Users;
using System.Text.Json.Serialization;

namespace EntityDTO.Statistic
{
    public class CalendarStatisticDto: EntityDtoBase
    {
        public int UserId { get; set; }
        [JsonIgnore]
        public StudentDto Student { get; set; }
        
        public DateTime Date { get; set; }
        public int ActivityRate { get; set; }  
    }
}