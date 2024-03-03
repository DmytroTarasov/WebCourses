using EntityDTO.Abstract;

namespace EntityDTO.Users
{
    public class BadgeDto: EntityDtoBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
    }
}