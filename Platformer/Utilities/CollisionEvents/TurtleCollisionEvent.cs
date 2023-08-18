﻿using Platformer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Platformer.Utilities.CollisionEvents
{
    internal class TurtleCollisionEvent : BaseCollisionEvent
    {
        public override void Execute(ICollidable other, ICollidable thisObject)
        {
            float overlapX = CalculateOverlapX(other.Hitbox, thisObject.Hitbox);
            float overlapY = CalculateOverlapY(other.Hitbox, thisObject.Hitbox);
            PlayerCharacter p = other as PlayerCharacter;
            if (p == null) return;
            if (Math.Abs(overlapX /= p.Hitbox.Width) >= Math.Abs(overlapY /= p.Hitbox.Height) && overlapY > 0)
            {
                Random rng = new();
                p.KnockBack(rng.Next(-1, 1), -6f);
            }
            else
            {
                if (overlapX < 0)
                {
                    p.KnockBack(5f, -2f);
                }
                else
                {
                    p.KnockBack(-5f, -2f);
                }
            }
            p.TakeDamage(1);
            p.DisableInput(0.3d);
        }
    }
}
