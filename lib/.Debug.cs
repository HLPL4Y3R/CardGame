using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;

namespace CardGame
{
    public class Debug
    {
        public Debug()
        {
        
        }

        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch, Input input)
        {
            spriteBatch.DrawString(Media.font_Monkey12, "PX: " + input.MouseCurrentState.X.ToString(), new Vector2(10, 10), Color.White);
            spriteBatch.DrawString(Media.font_Monkey12, "PY: " + input.MouseCurrentState.Y.ToString(), new Vector2(10, 24), Color.White);
            spriteBatch.DrawString(Media.font_Monkey12, "CX: " + input.ClickPressedPosition.X.ToString(), new Vector2(10, 42), Color.White);
            spriteBatch.DrawString(Media.font_Monkey12, "CY: " + input.ClickPressedPosition.Y.ToString(), new Vector2(10, 56), Color.White);
            spriteBatch.DrawString(Media.font_Monkey12, "RX: " + input.ClickReleasedPosition.X.ToString(), new Vector2(10, 74), Color.White);
            spriteBatch.DrawString(Media.font_Monkey12, "RY: " + input.ClickReleasedPosition.Y.ToString(), new Vector2(10, 88), Color.White);
        }
    }
}
