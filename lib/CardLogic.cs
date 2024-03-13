using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;


namespace CardGame
{
    public static class CardLogic
    {
        public static ushort CommonCardsTotal = 2;
        public static ushort RareCardsTotal = 2;
        public static ushort MythicalCardsTotal = 2;

        public static ushort CommonCardsIndex = 0;
        public static ushort RareCardsIndex = 256;
        public static ushort MythicalCardsIndex = 512;

        public static Card GetRandomCard()
        {
            Random rngCall = new Random();
            switch (rngCall.Next(0, 9))
            {
                case < 6: return GetCardInfo((ushort)(rngCall.Next(1, CommonCardsTotal) + CommonCardsIndex));
                case < 9: return GetCardInfo((ushort)(rngCall.Next(1, RareCardsTotal) + RareCardsIndex));
                case 9: return GetCardInfo((ushort)(rngCall.Next(1, MythicalCardsTotal) + MythicalCardsIndex));
                default: return GetCardInfo(0);
            }
        }

        public static List<Card> GetRandomCards(byte amount)
        {
            List<Card> cardList = new List<Card>();
            for (int i = 0; i < amount; i++)
            {
                cardList.Add(GetRandomCard());
            }
            return cardList;
        }

        public static Card GetCardInfo(ushort cardID)
        {
            Card card;
            switch (cardID)
            {
                case 1:
                    card = new Card(cardID, 0);
                    card.Name = "CommonVariant1";
                    card.PhysicalDamage = 5;
                    card.Texture = Media.debug_Card;
                    return card;

                case 2:
                    card = new Card(cardID, 0);
                    card.Name = "CommonVariant2";
                    card.PhysicalDamage = 5;
                    card.Texture = Media.debug_Card;
                    return card;

                case 257:
                    card = new Card(cardID, 0);
                    card.Name = "RareVariant1";
                    card.PhysicalDamage = 5;
                    card.Texture = Media.debug_Card;
                    return card;

                case 258:
                    card = new Card(cardID, 0);
                    card.Name = "RareVariant2";
                    card.PhysicalDamage = 5;
                    card.Texture = Media.debug_Card;
                    return card;

                case 513:
                    card = new Card(cardID, 0);
                    card.Name = "MythicalVariant1";
                    card.PhysicalDamage = 5;
                    card.Texture = Media.debug_Card;
                    return card;

                case 514:
                    card = new Card(cardID, 0);
                    card.Name = "MythicalVariant2";
                    card.PhysicalDamage = 5;
                    card.Texture = Media.debug_Card;
                    return card;

                default:
                    card = new Card(cardID, 0);
                    card.Name = "Debug";
                    card.PhysicalDamage = 5;
                    card.Texture = Media.debug_Card;
                    return card;
            }
        }

        public static void GetCardLogic(sbyte cardID)
        {

        }
    }
}
