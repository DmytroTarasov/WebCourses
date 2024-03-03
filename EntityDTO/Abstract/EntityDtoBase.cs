using System.ComponentModel.DataAnnotations;

namespace EntityDTO.Abstract
{
    public class EntityDtoBase: IEntity<int>
    {
        [Key] 
        public int Id { get; set; }

    }
}