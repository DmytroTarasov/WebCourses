using System.ComponentModel.DataAnnotations;
using EntityDTO.Abstract;

namespace EntityDTO.Course_Structure
{
    public class ActivityTypeDto: IEntity<string>
    {
        [Key]
        public string Id { get; set; }
    }
}