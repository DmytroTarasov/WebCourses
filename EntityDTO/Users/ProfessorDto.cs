using System.Collections;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using EntityDTO.Abstract;
using EntityDTO.Course_Structure;


namespace EntityDTO.Users
{
    public class ProfessorDto: EntityDtoBase
    {
        [JsonIgnore] [Newtonsoft.Json.JsonIgnore] public IEnumerable<CourseDto> Courses { get; set; }
        
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        [JsonIgnore] public string Password { get; set; }
        public string Token { get; set; }
    }
}