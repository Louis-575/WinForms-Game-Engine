using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WinFormsGameEngineAPI
{
    public enum EntityType
    {
        Default,
        Immovable
    }
    public static class EntityFactory
    {
        public static IEntity CreateEntity(EntityType entityType)
        {
            IEntity entity = null;
            switch (entityType)
            {
                case EntityType.Default:
                    entity = new Entity();
                    break;
                case EntityType.Immovable:
                    entity = new Immovable();
                    break;
                default:
                    break;
            }
            return entity;
        }
        public static IEntity CreateEntity(EntityType entityType, string name)
        {
            IEntity entity = null;
            switch (entityType) 
            {
                case EntityType.Default:
                    entity = new Entity(name);
                    break;
                case EntityType.Immovable:
                    entity = new Immovable(name);
                    break;
                default:
                    break;
            }
            return entity;
        }
        public static IEntity CreateEntity(EntityType entityType, string name, float mass, float[] size, float[] position)
        {
            IEntity entity = null;
            switch (entityType)
            {
                case EntityType.Default:
                    entity = new Entity(name, mass, size, position);
                    break;
                case EntityType.Immovable:
                    entity = new Immovable(name, mass, size, position);
                    break;
                default:
                    break;
            }
            return entity;
        }
        public static IEntity CreateEntity(EntityType entityType, string name, float mass, float[] size, float[] position, float[] velocity)
        {
            IEntity entity = null;
            switch (entityType)
            {
                case EntityType.Default:
                    entity = new Entity(name, mass, size, position, velocity);
                    break;
                case EntityType.Immovable:
                    entity = new Immovable(name, mass, size, position, velocity);
                    break;
                default:
                    break;
            }
            return entity;
        }
        public static IEntity CreateEntity(EntityType entityType, string name, float mass, float[] size, float[] position, float[] velocity, bool collisions)
        {
            IEntity entity = null;
            switch (entityType)
            {
                case EntityType.Default:
                    entity = new Entity(name, mass, size, position, velocity, collisions);
                    break;
                case EntityType.Immovable:
                    entity = new Immovable(name, mass, size, position, velocity, collisions);
                    break;
                default:
                    break;
            }
            return entity;
        }
    }
}
