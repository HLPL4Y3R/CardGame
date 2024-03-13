using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace CardGame
{
    internal static class Media
    {
        public static SpriteFont font_Monkey12;
        public static SpriteFont font_Monkey24;
        public static SpriteFont font_Monkey32;
        public static SpriteFont font_Monkey48;

        public static Texture2D debug_Card;
        public static Texture2D debug_Button;
        public static Texture2D debug_Box;

        public static void LoadMedia(ContentManager contentManager)
        {
            font_Monkey12 = contentManager.Load<SpriteFont>("fonts/Monkey_12");
            font_Monkey24 = contentManager.Load<SpriteFont>("fonts/Monkey_24");
            font_Monkey32 = contentManager.Load<SpriteFont>("fonts/Monkey_32");
            font_Monkey48 = contentManager.Load<SpriteFont>("fonts/Monkey_48");


            debug_Card = contentManager.Load<Texture2D>("graphics/debug_Card");
            debug_Button = contentManager.Load<Texture2D>("graphics/debug_Button");
            debug_Box = contentManager.Load<Texture2D>("graphics/debug_Box");
        }
    }
}
