using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using EntityDTO.Abstract;
using EntityDTO.Course_Structure;
using EntityDTO.Users;

namespace EntityDTO.Statistic
{
    public class LectureStatisticDto: EntityDtoBase
    {
        public int LectureId { get; set; }
        [JsonIgnore]
        public LectureDto Lecture { get; set; }
        public int UserId { get; set; }
        [JsonIgnore]
        public StudentDto Student { get; set; }

        public bool IsFinished { get; set; }
    }
}