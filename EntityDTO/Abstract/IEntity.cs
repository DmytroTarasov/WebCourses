using System;

namespace EntityDTO.Abstract
{
    public interface IEntity<TKey>
    {
        public TKey Id { get; set; }
    }
}