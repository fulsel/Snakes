using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Snake
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        List<Vector2> snake = new List<Vector2>();
        Texture2D snakeTexture;
        Texture2D pelletTexture;
        Vector2 food = new Vector2(5, 10);
        Vector2 direction = new Vector2(0, -1);
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            snakeTexture = Content.Load<Texture2D>("snake");
            pelletTexture = Content.Load<Texture2D>("pellet");
            // TODO: use this.Content to load your game content here

            snake.Add(new Vector2(40, 17));
            snake.Add(new Vector2(40, 18));
            snake.Add(new Vector2(40, 19));
            snake.Add(new Vector2(40, 20));
            snake.Add(new Vector2(40, 21));
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            
            
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();



            KeyboardState kb = Keyboard.GetState();
                
            if(kb.IsKeyDown(Keys.Left) && direction.X != 1)
                {
                    direction = new Vector2(-1, 0);
                }
            if (kb.IsKeyDown(Keys.Right) && direction.X != -1)
            {
                direction = new Vector2(1, 0);
            }
            if (kb.IsKeyDown(Keys.Up) && direction.Y != 1)
            {
                direction = new Vector2(0, -1);
            }
            if (kb.IsKeyDown(Keys.Down) && direction.Y != -1)
            {
                direction = new Vector2(0, 1);
            }




            if (snake[0] == food)
            {
                //snake.Add(snake[0]);
            }
           

            for (int i = snake.Count - 1; i > 0; i--)
            {
                snake[i] = snake[i - 1];
            }

            snake[0] += direction;


            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();

            for (int i = 0; i < snake.Count; i++)
            {
                spriteBatch.Draw(snakeTexture, new Rectangle((int)snake[i].X * 10, (int)snake[i].Y * 10, 10, 10), Color.White);
            }

            
                spriteBatch.Draw(pelletTexture, new Rectangle(10, 10, 10, 10), Color.White);
           



            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
