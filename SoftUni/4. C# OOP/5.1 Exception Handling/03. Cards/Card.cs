using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3
{
    internal class Card
    {
        public Card(string cardFace, CardSuit cardSuit)
        {
            CardFace = cardFace;
            CardSuit = cardSuit;
        }

        public string CardFace { get; set; }
        public CardSuit CardSuit { get; set; }

        public override string ToString()
        {
            char defaultSpadesSuit = '\u2660';

            switch (CardSuit)
            {
                case CardSuit.Hearts:
                    defaultSpadesSuit = '\u2665';
                    break;
                case CardSuit.Diamonds:
                    defaultSpadesSuit = '\u2666';
                    break;
                case CardSuit.Clubs:
                    defaultSpadesSuit = '\u2663';
                    break;
                default:
                    break;
            }
            return $"[{CardFace}{defaultSpadesSuit}]";
        }
    }
    public enum CardSuit
    {
        Spades,
        Hearts,
        Diamonds,
        Clubs
    }
}
