using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EntityDTO.Abstract;
using EntityDTO.Users;

namespace EntityDTO.Course_Structure
{
    public class ConstructTypeDto: IEntity<string>
    {
        [Key]
        public string Id { get; set; }
    }
}