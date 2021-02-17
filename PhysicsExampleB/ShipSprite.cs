using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace PhysicsExampleB
{
    /// <summary>
    /// A class representing the players' ship
    /// </summary>
    public class ShipSprite
    {
        public Texture2D texture;
        public Vector2 position;
        public Vector2 velocity;

        /// <summary>
        /// Creates the ship sprite
        /// </summary>
        public ShipSprite()
        {
            position = new Vector2(375, 250);
        }

        /// <summary>
        /// Loads the sprite texture
        /// </summary>
        /// <param name="content">The content manager to load with</param>
        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("ship");
        }

        /// <summary>
        /// Updates the ship sprite
        /// </summary>
        /// <param name="gameTime">An object representing time in the game</param>
        public void Update(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();

        }

        /// <summary>
        /// Draws the sprite
        /// </summary>
        /// <param name="gameTime">An object representing time in the game</param>
        /// <param name="spriteBatch">The SpriteBatch to draw with</param>
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }
    }
}
