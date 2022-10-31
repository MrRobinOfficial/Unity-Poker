using System;
using UnityEngine;

namespace UnityPoker.Framework
{
    public enum CardSuit : byte
    {
        Spades,
        Hearts,
        Diamonds,
        Clubs
    }

    public enum CardType : byte
    {
        Blank,
        Ace,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King
    }

    public readonly struct Card : IEquatable<Card>
    {
        public readonly CardSuit suit;
        public readonly CardType type;

        /// <summary>
        /// Calculate the score based on this <a href="https://www.thepokerbank.com/strategy/basic/starting-hand-selection/chen-formula/">article</a>
        /// </summary>
        /// <returns></returns>
        public float GetScore() => type switch
        {
            CardType.Ace => 10f,
            CardType.King => 8f,
            CardType.Queen => 7f,
            CardType.Jack => 6f,
            CardType.Ten => 5f,
            CardType.Nine => 4.5f,
            CardType.Eight => 4,
            CardType.Seven => 3.5f,
            CardType.Six => 3f,
            CardType.Five => 2.5f,
            CardType.Four => 2f,
            CardType.Three => 1.5f,
            CardType.Two => 1,
            _ => 0,
        };

        public Card(CardSuit suit, CardType type)
        {
            this.suit = suit;
            this.type = type;
        }

        public bool Equals(Card other) => type == other.type && suit == other.suit;

        public override string ToString() => $"{suit}:{type}";
    }
}

namespace UnityPoker.Framework.Extensions
{
    public static partial class FrameworkExtensions
    {

    }
}
