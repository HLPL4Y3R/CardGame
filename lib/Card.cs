using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CardGame
{
    public class Card
    {
        public ushort ID;
        public Vector2 Position;
        private Rectangle Bounds;
        public readonly byte Rarity;
        public readonly byte Behavior; //The type of behavior, used to skip condition checks. 0: Generic Attack, 1: Generic Defense, 2: Conditional

        public Texture2D Texture;
        public string Name;

        public short PhysicalDamage;
        public short MagicDamage;

        public short PhysicalDefence;
        public short MagicDefence;

        public Card(ushort ID, byte behavior)
        {
            //Switches doesn't work with non-constant values.
            Rarity = 0;
            if (ID > CardLogic.RareCardsIndex)
                Rarity = 0;
            else if (ID > CardLogic.MythicalCardsIndex)
                Rarity = 1;

            Behavior = behavior;
            Bounds = new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height);
        }
    }
}
