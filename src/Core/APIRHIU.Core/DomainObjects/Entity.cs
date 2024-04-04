﻿namespace APIRHIU.Core.DomainObjects
{
    public abstract class Entity
    {
        public Guid Id { get; set; }

        protected Entity()
        {
            Id = new Guid(); 
        }
    }
}