
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer.Managers
{
    internal class ContentManager
    {
        public Texture2D LevelBackgroundTexture { get; set; }
        public Texture2D FrogTexture { get; set; }
        public Texture2D MushroomTexture { get; set; }
        public Texture2D TerrainTexture { get; set; }
        public Texture2D ButtonTexture { get; set; }
        public Texture2D TitleScreenBackgroundTexture { get; set; }
        public Texture2D Title { get; set; }
        public Texture2D HeartTexture { get; set; }
        public Texture2D HeartSpritesheetTexture { get; set; }
        public SpriteFont ButtonFont { get; set; }
        public Texture2D SpikeTexture { get; set; }
        public Texture2D VictoryBackgroundTexture { get; set; }
        public Texture2D GameOverBackgroundTexture { get; set; }
        public Texture2D AppleSpritesheetTexture { get; set; }
        public Texture2D Victory { get; set; }
        public Texture2D GameOver { get; set; }
        public Texture2D TurtleTexture { get; set; }
        public Texture2D BulletTexture { get; set; }
        public Song MenuSoundtrack {get; set;}
        public Song MarioSoundtrack {get; set;}
        public Song VictorySoundtrack { get; set; }
        public Song DefeatSoundtrack { get; set; }
        public SoundEffect MenuSelectionSoundEffect {get; set; }
        public SoundEffect JumpSoundEffect { get; set; }
        public SoundEffect HurtSoundEffect { get; set; }
        public Texture2D KamikazeTexture { get; set; }
        public SoundEffect PowerupSoundEffect { get; set; }
        public SoundEffect AmmunitionSoundEffect { get; set; }
        public SoundEffect HurtEnemySoundEffect { get; set; }

        private static ContentManager instance;
        private ContentManager(){}
        public static ContentManager Instance()
        {
            instance ??= new ContentManager();
            return instance;
        }
        public void Initialize(Game1 game)
        {
            FrogTexture = game.Content.Load<Texture2D>("Entities/player_characters/Frog");
            MushroomTexture = game.Content.Load<Texture2D>("Entities/enemies/Mushroom");
            TerrainTexture = game.Content.Load<Texture2D>("Terrain/Terrain (16 x 16)");
            ButtonTexture = game.Content.Load<Texture2D>("UI/Button1");
            HeartTexture = game.Content.Load<Texture2D>("UI/Heart");
            LevelBackgroundTexture = game.Content.Load<Texture2D>("Backgrounds/Level_background");
            TitleScreenBackgroundTexture = game.Content.Load<Texture2D>("Backgrounds/Startscreen_background_spritesheet");
            HeartSpritesheetTexture = game.Content.Load<Texture2D>("Terrain/Heart_spritesheet");
            AppleSpritesheetTexture = game.Content.Load<Texture2D>("Terrain/Apple_spritesheet");
            Title = game.Content.Load<Texture2D>("Fonts/Title");
            TurtleTexture = game.Content.Load<Texture2D>("Entities/Enemies/Turtle");
            GameOver = game.Content.Load<Texture2D>("Fonts/GameOver");
            SpikeTexture = game.Content.Load<Texture2D>("Terrain/Spikes");
            BulletTexture = game.Content.Load<Texture2D>("Entities/projectiles/Bullet");
            GameOverBackgroundTexture = game.Content.Load<Texture2D>("Backgrounds/GameOver_background");
            VictoryBackgroundTexture = game.Content.Load<Texture2D>("Backgrounds/Victory_background");
            Victory = game.Content.Load<Texture2D>("Fonts/Victory");
            ButtonFont = game.Content.Load<SpriteFont>("Fonts/ButtonText");
            MenuSoundtrack = game.Content.Load<Song>("Audio/Osrs_Soundtrack");
            VictorySoundtrack = game.Content.Load<Song>("Audio/Victory_Soundtrack");
            DefeatSoundtrack = game.Content.Load<Song>("Audio/Defeat_Soundtrack");
            MenuSelectionSoundEffect = game.Content.Load<SoundEffect>("Audio/MenuSelection_Soundeffect");
            PowerupSoundEffect = game.Content.Load<SoundEffect>("Audio/Powerup_Soundeffect");
            MarioSoundtrack = game.Content.Load<Song>("Audio/Mario_Soundtrack");
            JumpSoundEffect = game.Content.Load<SoundEffect>("Audio/Jump_Soundeffect");
            HurtSoundEffect = game.Content.Load<SoundEffect>("Audio/Hurt_Soundeffect");
            KamikazeTexture = game.Content.Load<Texture2D>("Entities/enemies/Kamikaze");
            AmmunitionSoundEffect = game.Content.Load<SoundEffect>("Audio/Ammunition_Soundeffect");
            HurtEnemySoundEffect = game.Content.Load<SoundEffect>("Audio/HurtEnemy_Soundeffect");
        }
    }
}
