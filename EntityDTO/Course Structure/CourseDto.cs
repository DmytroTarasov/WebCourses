using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using EntityDTO.Abstract;
using EntityDTO.Users;

namespace EntityDTO.Course_Structure
{
    public class CourseDto: EntityDtoBase
    {
        public string CategoryId { get; set; }
        [JsonIgnore]  public CourseCategoryDto Category { get; set; }
        [JsonIgnore] [Newtonsoft.Json.JsonIgnore] public IEnumerable<ProfessorDto> Authors { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
    }
}