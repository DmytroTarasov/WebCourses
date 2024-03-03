using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using EntityDTO.Abstract;
using EntityDTO.Activities;
using EntityDTO.Users;

namespace EntityDTO.Statistic
{
    public class TestStatisticDto: EntityDtoBase
    {
        public int TestId { get; set; }
        [JsonIgnore]
        public TestDto Test { get; set; }
        public int UserId { get; set; }
        [JsonIgnore]
        public StudentDto Student { get; set; }

        public int Score { get; set; }
    }
}