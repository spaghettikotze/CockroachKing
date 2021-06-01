using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace CockroachKing
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private KeyboardListener keyboard;
        private MouseListener mouse;

        private Vector2 scale;
        private Vector2 resolution;

        private Texture2D spritePlayer;
        private Texture2D spriteLadder;
        private Texture2D spriteBackground;

        private Player player;                              //Objekt der Klasse player

        List<GameObject> gameObjects;               //Liste für die Game objekte wird initialisiert

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";          //content folder
            IsMouseVisible = true;
            graphics.IsFullScreen = true;

        }

        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            //graphics.PreferredBackBufferWidth = 960;
            //graphics.PreferredBackBufferHeight = 540;
            resolution = new Vector2(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
            graphics.ApplyChanges();
            scale = new Vector2(resolution.X / 1920, resolution.Y / 1080);

            keyboard = new KeyboardListener();
            mouse = new MouseListener();
            Console.OpenStandardOutput();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            spritePlayer = this.Content.Load<Texture2D>("main_character");                      //hier neuer player erzeugen
            spriteLadder = this.Content.Load<Texture2D>("sprite_ladder");
            spriteBackground = this.Content.Load<Texture2D>("background_house");

            gameObjects = new List<GameObject>();
            player = Helper.SpawnPlayer(spritePlayer, new Vector2(resolution.X / 7, resolution.Y / 1.87f), 0.5f, scale);
            gameObjects.Add(player);
            /*ladder = new Ladder(spriteLadder, new Vector2(0.03229166667f * resolution.X, 0.0462962963f * resolution.Y));
            gameObjects.Add(ladder);*/

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            mouse.Update();
            keyboard.Update();

            for (int i = 0; i < gameObjects.Count; i++)
            {
                GameObject current = gameObjects[i];

                if (current is Player)
                {
                    player = (Player)current;

                    Helper.PlayerHandler(player, mouse, keyboard);
                    
                    player.Update(gameTime);                    
                }
            }


                base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here

            spriteBatch.Begin();
            spriteBatch.Draw(spriteBackground, new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), Color.White);

            foreach (GameObject current in gameObjects)
            {
                spriteBatch.Draw(current.Sprite, current.Position, null, Color.White, current.Rotation, new Vector2(current.Sprite.Width / 2, current.Sprite.Height / 2), scale, SpriteEffects.None, 0f);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }


    }
}