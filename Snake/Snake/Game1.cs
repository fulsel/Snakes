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
        Random rand = new Random(System.Environment.TickCount);

        Texture2D squareTexture;
        int playerScore = 0;
        float timeRemaining = 0.0f;
        const float TimePerSquare = 30f;
        Song a;
        Texture2D astleyheadtexture;
        

        float foodRemaining = 0.0f;
        const float TimePerFood = 3500f;

        Color[] colors = new Color[3] { Color.Red, Color.Green,
        Color.Blue };
        List<Vector2> snake = new List<Vector2>();
        Texture2D snakeTexture;
        Texture2D pelletTexture;
        Vector2 food = new Vector2(5, 10);
        Vector2 direction = new Vector2(0, -1);


        /*float timeRemaining = 0.0f;
        const float TimePerSquare = 0.75f;
        Random rand = new Random();
        Texture2D squareTexture;
        Rectangle currentSquare;
        int playerScore = 0;
        Color[] colors = new Color[3] { Color.Red, Color.Green,
Color.Blue };*/
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
            //a = Content.Load<Song>("a");
            //astleyheadtexture = Content.Load<Texture2D>("astley_head");
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
            MediaPlayer.Play(a);
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

                if (kb.IsKeyDown(Keys.Left) && direction.X != 1)
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

                if (foodRemaining <= 0)
                {
                    food = new Vector2(rand.Next(1, 60), rand.Next(1, 40));
                    foodRemaining = TimePerFood;
                }


                if (timeRemaining <= 0.0f)
                {


                    if (snake[0] == food)
                    {
                        snake.Add(snake[0]);
                        playerScore++;
                        food = new Vector2(rand.Next(1,20), rand.Next(1,20));
                        foodRemaining = TimePerFood;
                    }


                    for (int i = snake.Count - 1; i > 0; i--)
                    {
                        snake[i] = snake[i - 1];
                    }

                    snake[0] += direction;

                    /*  if (timeRemaining == 0.0f)
                    {
                        currentSquare = new Rectangle(
                                                        rand.Next(0, this.Window.ClientBounds.Width - 25),
                                                        rand.Next(0, this.Window.ClientBounds.Height - 25),
                                                        25, 25);
                        timeRemaining = TimePerSquare;
                    }
                     */

                    for(int i = 0; i < snake.Count; i++)
                    {
                        if (snake[i].X < 0)
                        {
                            snake[0] = new Vector2(40, 17);
                            playerScore--;
                            snake.Clear();
                            snake.Add(new Vector2(40, 17));
                            snake.Add(new Vector2(40, 18));
                            snake.Add(new Vector2(40, 19));
                            snake.Add(new Vector2(40, 20));
                            snake.Add(new Vector2(40, 21));
                            direction = new Vector2(0, -1);
                            break;
                        }

                        if (snake[i].X > 80)
                        {
                            snake[0] = new Vector2(40, 17);
                            playerScore--;
                            snake.Clear();
                            snake.Add(new Vector2(40, 17));
                            snake.Add(new Vector2(40, 18));
                            snake.Add(new Vector2(40, 19));
                            snake.Add(new Vector2(40, 20));
                            snake.Add(new Vector2(40, 21));
                            direction = new Vector2(0, -1);
                            break;
                        }

                        if (snake[i].Y < 0)
                        {
                            snake[0] = new Vector2(40, 17);
                            playerScore--;
                            snake.Clear();
                            snake.Add(new Vector2(40, 17));
                            snake.Add(new Vector2(40, 18));
                            snake.Add(new Vector2(40, 19));
                            snake.Add(new Vector2(40, 20));
                            snake.Add(new Vector2(40, 21));
                            direction = new Vector2(0, -1);
                            break;
                        }

                        if (snake[i].Y > 50)
                        {
                            snake[0] = new Vector2(40, 17);
                            playerScore--;
                            snake.Clear();
                            snake.Add(new Vector2(40, 17));
                            snake.Add(new Vector2(40, 18));
                            snake.Add(new Vector2(40, 19));
                            snake.Add(new Vector2(40, 20));
                            snake.Add(new Vector2(40, 21));
                            direction = new Vector2(0, -1);
                            break;
                        }

                        if (i > 0 && snake[0] == snake[i])
                        {
                            snake[0] = new Vector2(40, 17);
                            playerScore--;
                            snake.Clear();
                            snake.Add(new Vector2(40, 17));
                            snake.Add(new Vector2(40, 18));
                            snake.Add(new Vector2(40, 19));
                            snake.Add(new Vector2(40, 20));
                            snake.Add(new Vector2(40, 21));
                            break;
                        }
                    }

                    timeRemaining = TimePerSquare;
                }
                
                timeRemaining = timeRemaining - (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                foodRemaining = foodRemaining - (float)gameTime.ElapsedGameTime.TotalMilliseconds;

                this.Window.Title = "Score : " + playerScore.ToString();
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.SandyBrown);
            spriteBatch.Begin();

           

            for (int i = 0; i < snake.Count; i++)
            {
                spriteBatch.Draw(snakeTexture, new Rectangle((int)snake[i].X * 10, (int)snake[i].Y * 10, 10, 10), Color.White);
            }


            spriteBatch.Draw(pelletTexture, food * 10, Color.White);
            //spriteBatch.Draw(astleyheadtexture, 50, Color.White);



            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
