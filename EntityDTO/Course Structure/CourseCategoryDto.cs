using System.ComponentModel.DataAnnotations;
using EntityDTO.Abstract;

namespace EntityDTO.Course_Structure
{
    public class CourseCategoryDto : IEntity<string>
    {
        public string Id { get; set; }
    }
}