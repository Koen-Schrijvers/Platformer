using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Platformer.Terrain.Blocks
{
    internal class FillerBlock
    {
        public Vector2 Scale { get; set; }
        public Texture2D Texture { get; protected set; }
        public Vector2 Position { get; set; }
        protected Rectangle textureFrame;
        public FillerBlock(Vector2 scale, Texture2D texture, Vector2 position, Rectangle frame)
        {
            Scale = scale;
            Texture = texture;
            Position = position;
            textureFrame = frame;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                    Texture,
                    Position,
                    textureFrame,
                    Color.White,
                    0f,
                    Vector2.Zero,
                    Scale,
                    SpriteEffects.None,
                    0f);
        }
    }
}
