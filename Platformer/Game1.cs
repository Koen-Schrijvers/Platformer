using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Platformer.AnimationUtil;
using Platformer.Entities;
using Platformer.Entities.Enemies;
using Platformer.Levels;
using Platformer.Managers;
using Platformer.Terrain;
using Platformer.Terrain.Blocks;
using System.Linq.Expressions;

namespace Platformer
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private PlayerCharacter _character;
        private Mushroom mush;
        private Block blok;
        private FillerBlock blok2;
        private BaseLevel baseLevel;
        private Texture2D frogTexture;
        private Texture2D mushTexture;
        private Texture2D terrainTexture;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();
            Managers.ContentManager.Instance().Initialize(this);
            _character = new PlayerCharacter(frogTexture);
            mush = new Mushroom(mushTexture);
            blok = BlockFactory.CreateBasicBlock(BlockType.SOLO,terrainTexture,1,1,new Point(100,290),new Vector2(1f,1f));
            baseLevel = new BaseLevel(terrainTexture);
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            frogTexture = this.Content.Load<Texture2D>("Entities/player_characters/Frog");
            mushTexture = this.Content.Load<Texture2D>("Entities/enemies/Mushroom");
            terrainTexture = this.Content.Load<Texture2D>("Terrain/Terrain (16 x 16)");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            _character.Update(gameTime);
            mush.Update(gameTime);
            if (_character.Hitbox.Intersects(mush.Hitbox))
            {
                mush.CollisionEvent.Execute(_character, mush);
            }
            if (_character.Hitbox.Intersects(blok.Hitbox))
            {
                blok.CollisionEvent.Execute(_character, blok);
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _character.Draw(_spriteBatch);
            mush.Draw(_spriteBatch);
            blok.Draw(_spriteBatch);
            baseLevel.Draw(_spriteBatch);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
        private void DrawBlock(Vector2 position, Rectangle frame)
        {
            _spriteBatch.Draw(
                    terrainTexture,
                    position,
                    frame,
                    Color.White,
                    0f,
                    Vector2.Zero,
                    new Vector2(1f, 1f),
                    SpriteEffects.None,
                    0f);
        }
    }
}