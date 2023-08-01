using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Platformer.Terrain.Blocks;
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
        public static Block CreateBlock(BlockType type, Texture2D texture, int i, int j, Vector2 Position, int gridCellSize, Point drawOffset, Vector2 scale)
        {
            Block block;
            Rectangle frame;
            switch (type)
            {
                case BlockType.SOLO:
                    frame = new Rectangle(128, 32, 32, 32);
                    break;
                case BlockType.UPPER_LEFT:
                    frame = new Rectangle(160, 32, 32, 32);
                    break;
                case BlockType.UPPER_MIDDLE:
                    frame = new Rectangle(192, 32, 32, 32);
                    break;
                case BlockType.UPPER_RIGHT:
                    frame = new Rectangle(64, 32, 32, 32);
                    break;
                case BlockType.CENTER_LEFT:
                    frame = new Rectangle(64, 64, 32, 32);
                    break;
                case BlockType.CENTER_MIDDLE:
                    frame = new Rectangle(32, 96, 32, 32);
                    break;
                default:
                    frame = new Rectangle(128, 32, 32, 32);
                    break;
            }
            block = new BasicBlock(texture, frame, new Vector2 (i * frame.Width + drawOffset.X, j * gridCellSize + drawOffset.Y), scale);
            return block;
        }
    }
}
