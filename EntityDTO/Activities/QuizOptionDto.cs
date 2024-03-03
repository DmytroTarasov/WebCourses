using System;
using System.ComponentModel.DataAnnotations.Schema;
using EntityDTO.Abstract;
using System.Text.Json.Serialization;

namespace EntityDTO.Activities
{
    public class QuizOptionDto: EntityDtoBase
    {
        public int QuizId { get; set; }
        [JsonIgnore]
        public QuizDto Quiz{ get; set; }
        
        public string OptionText { get; set; }
        public bool IsCorrect { get; set; }
    }
}