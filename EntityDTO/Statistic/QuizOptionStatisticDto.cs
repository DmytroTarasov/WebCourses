using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using EntityDTO.Abstract;
using EntityDTO.Activities;
using EntityDTO.Users;

namespace EntityDTO.Statistic
{
    public class QuizOptionStatisticDto: EntityDtoBase
    {
        public int QuizOptionId { get; set; }
        [JsonIgnore]
        public QuizOptionDto QuizOption { get; set; }
        public int UserId { get; set; }
        [JsonIgnore]
        public StudentDto Student { get; set; }
    }
}