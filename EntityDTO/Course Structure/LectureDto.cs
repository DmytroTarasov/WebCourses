using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using EntityDTO.Abstract;
using EntityDTO.Users;

namespace EntityDTO.Course_Structure
{
    public class LectureDto: EntityDtoBase
    {
        public int TopicId { get; set; }
        [JsonIgnore]
        public TopicDto Topic { get; set; }
        public int ProfessorId { get; set; }
        [JsonIgnore]
        public ProfessorDto Professor { get; set; }

        public string Name { get; set; }
        //TODO Return only finished Lectures
        public bool IsFinished { get; set; }
        
    }
}