using System;
using System.Text.Json.Serialization;
using EntityDTO.Abstract;


namespace EntityDTO.Course_Structure
{
    public class LectureConstructDto: EntityDtoBase
    {
        [JsonIgnore]
        public LectureDto Lecture { get; set; }
        public int LectureId { get; set; }

        public string ConstructTypeId { get; set; }
        [JsonIgnore]
        public ConstructTypeDto ConstructType { get; set; }
        
        public int DisplayOrder { get; set; }
        public string Content { get; set; }
    }
}