using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;


namespace CardGame
{
    internal class Player
    {
        public string Name;

        public short Health;
        public short Mana;
        public short Money;

        public List<Card> CardInventory;
        public Player(short health, short mana, short money)
        {
            CardInventory = CardLogic.GetRandomCards(10);
            Health = health;
            Mana = mana;
            Money = money;
        }

        public void DrawCards(SpriteBatch spriteBatch)
        {
        }
    }
}
