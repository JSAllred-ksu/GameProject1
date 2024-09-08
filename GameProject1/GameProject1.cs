using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Linq;

namespace GameProject1
{
    public class GameProject1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private ShipSprite ship;
        private Texture2D background;
        private AsteroidSprite[] asteroids;

        /// <summary>
        /// Creates a new game
        /// </summary>
        public GameProject1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        /// <summary>
        /// Initializes the game
        /// </summary>
        protected override void Initialize()
        {
            System.Random rand = new System.Random();
            asteroids = new AsteroidSprite[10];

            for (int i = 0; i < asteroids.Length; i++)
            {
                float randomAngularSpeed = (float)(rand.NextDouble()); 
                Vector2 randomPosition = new Vector2((float)rand.NextDouble() * GraphicsDevice.Viewport.Width, (float)rand.NextDouble() * GraphicsDevice.Viewport.Height);
                asteroids[i] = new AsteroidSprite(randomPosition, randomAngularSpeed);
            }

            ship = new ShipSprite(this);

            base.Initialize();
        }

        /// <summary>
        /// Loads the game content
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            ship.LoadContent(Content);
            background = Content.Load<Texture2D>("Nebula");
            foreach (var asteroid in asteroids)
            {
                asteroid.LoadContent(Content);
            }
        }

        /// <summary>
        /// Updates the game
        /// </summary>
        /// <param name="gameTime">An object representing time in the game</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            for (int i = 0; i < asteroids.Length; i++)
            {
                if (asteroids[i] != null && !asteroids[i].Destroyed)
                {
                    asteroids[i].Update(gameTime, ship);
                }
                else if (asteroids[i]?.Destroyed == true)
                {
                    asteroids[i] = null;
                }
            }

            ship.Update(gameTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// Draws the game
        /// </summary>
        /// <param name="gameTime">An object representing time in the game</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();
            spriteBatch.Draw(background, new Rectangle(0, 0, (int)GraphicsDevice.Viewport.Width, (int)GraphicsDevice.Viewport.Height), Color.White);
            ship.Draw(gameTime, spriteBatch);

            foreach (var asteroid in asteroids.Where(a => a != null))
            {
                asteroid.Draw(gameTime, spriteBatch);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
