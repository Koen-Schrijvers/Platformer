using Platformer.Entities;
using Platformer.Entities.Enemies;
using Platformer.Levels;
using Platformer.Terrain.Blocks;
using Platformer.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Platformer.Managers
{
    internal class CollisionManager
    {
        private static CollisionManager instance;
        public BaseLevel CurrentLevel { get; set; }
        private CollisionManager() 
        {
            
        }
        public static CollisionManager Instance()
        {
            instance ??= new CollisionManager();
            return instance;
        }

        private List<ICollidable> FindCollisions(ICollidable entity)
        {
            List<ICollidable> collisions = new List<ICollidable>();
            CurrentLevel.Collidables.ForEach(b =>
            {
                if (entity.Hitbox.Intersects(b.Hitbox)) collisions.Add(b);
            });
            return collisions;
        }
        public void HandleCollisions(ICollidable entity)
        {
            List<ICollidable> collisions = FindCollisions(entity);
            collisions.Sort(new CollidableComparer(entity.Hitbox));
            collisions.ForEach(x =>
            {
                x.CollisionEvent.Execute(entity,x);
            });
            // zorg dat enemies enkel met terrain collide of geen collisions doen
        }
    }
}
