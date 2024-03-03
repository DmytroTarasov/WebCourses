using EntityDTO.Abstract;
using Newtonsoft.Json;

namespace EntityDTO.Users
{
    public class StudentDto: EntityDtoBase
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        [JsonIgnore] public string Password { get; set; }
        public string Token { get; set; }
    }
}