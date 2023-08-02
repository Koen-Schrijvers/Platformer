using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Platformer.Terrain.Blocks;
using Platformer.Utilities.CollisionEvents;
using SharpDX.Direct2D1.Effects;
using SharpDX.Direct3D9;
using SharpDX.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer.Terrain
{
    internal class BlockFactory
    {
        public static BasicBlock CreateBasicBlock(BlockType type, int i, int j, Point drawOffset, Vector2 scale)
        {
            Rectangle frame =  SelectFrame(type);
            return new BasicBlock(
                frame, 
                new Vector2 (
                    j * frame.Width * scale.X + drawOffset.X, 
                    i * frame.Width * scale.Y + drawOffset.Y
                    ), 
                scale,
                new BlockMovementCollisionEvent()
                );
        }
        public static Block createTrap()
        {
            return null;
        }
        private static Rectangle SelectFrame(BlockType type)
        {
            Rectangle frame;
            switch (type)
            {
                case BlockType.SOLO:
                    frame = new Rectangle(240, 48, 16, 16);
                    break;
                case BlockType.UPPER_LEFT:
                    frame = new Rectangle(48, 16, 16, 16);
                    break;
                case BlockType.UPPER_MIDDLE:
                    frame = new Rectangle(64, 16, 16, 16);
                    break;
                case BlockType.UPPER_RIGHT:
                    frame = new Rectangle(80, 16, 16, 16);
                    break;
                case BlockType.CENTER_LEFT:
                    frame = new Rectangle(48, 32, 16, 16);
                    break;
                case BlockType.CENTER_MIDDLE:
                    frame = new Rectangle(64, 32, 16, 16);
                    break;
                case BlockType.CENTER_RIGHT:
                    frame = new Rectangle(80, 32, 16, 16);
                    break;
                case BlockType.LOWER_LEFT:
                    frame = new Rectangle(48, 96, 16, 16);
                    break;
                case BlockType.LOWER_MIDDLE:
                    frame = new Rectangle(64, 96, 16, 16);
                    break;
                case BlockType.LOWER_RIGHT:
                    frame = new Rectangle(80, 96, 16, 16);
                    break;
                case BlockType.LOWER_LEFT_GRASS:
                    frame = new Rectangle(48, 48, 16, 16);
                    break;
                case BlockType.LOWER_RIGHT_GRASS:
                    frame = new Rectangle(80, 48, 16, 16);
                    break;
                case BlockType.PLATFORM_LEFT:
                    frame = new Rectangle(144, 48, 16, 16);
                    break;
                case BlockType.PLATFORM_RIGHT:
                    frame = new Rectangle(208, 48, 16, 16);
                    break;
                case BlockType.PLATFORM_MIDDLE:
                    frame = new Rectangle(160, 48, 16, 16);
                    break;
                default:
                    frame = new Rectangle(240, 48, 16, 16);
                    break;
            }
            return frame;
        }
    }
}
