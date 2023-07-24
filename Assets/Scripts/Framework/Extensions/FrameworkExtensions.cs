using System;
using UnityEngine;

namespace UnityPoker.Framework
{
    public enum CardSuit : byte
    {
        Spades = 40,
        Hearts = 80,
        Diamonds = 120,
        Clubs = 160
    }

    public enum CardValue : byte
    {
        Blank = 0,
        Ace = 1,
        Two = 3,
        Three = 5,
        Four = 7,
        Five = 9,
        Six = 11,
        Seven = 13,
        Eight = 15,
        Nine = 17,
        Ten = 19,
        Jack = 21,
        Queen = 23,
        King = 25
    }

    public enum CardRank : byte
    {
        Blank = 0,

        Spade_Ace = CardValue.Ace + CardSuit.Spades,
        Spade_Two = CardValue.Two + CardSuit.Spades,
        Spade_Three = CardValue.Three + CardSuit.Spades,
        Spade_Four = CardValue.Four + CardSuit.Spades,
        Spade_Five = CardValue.Five + CardSuit.Spades,
        Spade_Six = CardValue.Six + CardSuit.Spades,
        Spade_Seven = CardValue.Seven + CardSuit.Spades,
        Spade_Eight = CardValue.Eight + CardSuit.Spades,
        Spade_Nine = CardValue.Nine + CardSuit.Spades,
        Spade_Ten = CardValue.Ten + CardSuit.Spades,
        Spade_Jack = CardValue.Jack + CardSuit.Spades,
        Spade_Queen = CardValue.Queen + CardSuit.Spades,
        Spade_King = CardValue.King + CardSuit.Spades,

        Hearts_Ace = CardValue.Ace + CardSuit.Hearts,
        Hearts_Two = CardValue.Two + CardSuit.Hearts,
        Hearts_Three = CardValue.Three + CardSuit.Hearts,
        Hearts_Four = CardValue.Four + CardSuit.Hearts,
        Hearts_Five = CardValue.Five + CardSuit.Hearts,
        Hearts_Six = CardValue.Six + CardSuit.Hearts,
        Hearts_Seven = CardValue.Seven + CardSuit.Hearts,
        Hearts_Eight = CardValue.Eight + CardSuit.Hearts,
        Hearts_Nine = CardValue.Nine + CardSuit.Hearts,
        Hearts_Ten = CardValue.Ten + CardSuit.Hearts,
        Hearts_Jack = CardValue.Jack + CardSuit.Hearts,
        Hearts_Queen = CardValue.Queen + CardSuit.Hearts,
        Hearts_King = CardValue.King + CardSuit.Hearts,

        Diamonds_Ace = CardValue.Ace + CardSuit.Diamonds,
        Diamonds_Two = CardValue.Two + CardSuit.Diamonds,
        Diamonds_Three = CardValue.Three + CardSuit.Diamonds,
        Diamonds_Four = CardValue.Four + CardSuit.Diamonds,
        Diamonds_Five = CardValue.Five + CardSuit.Diamonds,
        Diamonds_Six = CardValue.Six + CardSuit.Diamonds,
        Diamonds_Seven = CardValue.Seven + CardSuit.Diamonds,
        Diamonds_Eight = CardValue.Eight + CardSuit.Diamonds,
        Diamonds_Nine = CardValue.Nine + CardSuit.Diamonds,
        Diamonds_Ten = CardValue.Ten + CardSuit.Diamonds,
        Diamonds_Jack = CardValue.Jack + CardSuit.Diamonds,
        Diamonds_Queen = CardValue.Queen + CardSuit.Diamonds,
        Diamonds_King = CardValue.King + CardSuit.Diamonds,

        Clubs_Ace = CardValue.Ace + CardSuit.Clubs,
        Clubs_Two = CardValue.Two + CardSuit.Clubs,
        Clubs_Three = CardValue.Three + CardSuit.Clubs,
        Clubs_Four = CardValue.Four + CardSuit.Clubs,
        Clubs_Five = CardValue.Five + CardSuit.Clubs,
        Clubs_Six = CardValue.Six + CardSuit.Clubs,
        Clubs_Seven = CardValue.Seven + CardSuit.Clubs,
        Clubs_Eight = CardValue.Eight + CardSuit.Clubs,
        Clubs_Nine = CardValue.Nine + CardSuit.Clubs,
        Clubs_Ten = CardValue.Ten + CardSuit.Clubs,
        Clubs_Jack = CardValue.Jack + CardSuit.Clubs,
        Clubs_Queen = CardValue.Queen + CardSuit.Clubs,
        Clubs_King = CardValue.King + CardSuit.Clubs
    }

    public enum HandRank : byte
    {
        RoyalFlush = 10,
        StraightFlush = 9,
        FourOfAKind = 8,
        FullHouse = 7,
        Flush = 6,
        Straight = 5,
        ThreeOfAKind = 4,
        TwoPair = 3,
        OnePair = 2,
        HighCard = 1,
        Fold = 0,
        Undefined = Fold,
    }

    public readonly struct Card : IEquatable<Card>
    {
        public readonly CardSuit suit;
        public readonly CardValue value;

        public int GetSuitScore() => suit switch
        {
            CardSuit.Clubs => 4, // 4x4 = 16
            CardSuit.Spades => 3, // 3x4 = 12
            CardSuit.Diamonds => 2, // 2x4 = 8
            CardSuit.Hearts => 1, // 1x4 = 4
            _ => 0,
        };

        /// <summary>
        /// Calculate the score based on this <a href="https://www.thepokerbank.com/strategy/basic/starting-hand-selection/chen-formula/">article</a>
        /// </summary>
        /// <returns></returns>
        public float GetValueScore() => value switch
        {
            CardValue.Ace => 10f,
            CardValue.King => 8f,
            CardValue.Queen => 7f,
            CardValue.Jack => 6f,
            CardValue.Ten => 5f,
            CardValue.Nine => 4.5f,
            CardValue.Eight => 4,
            CardValue.Seven => 3.5f,
            CardValue.Six => 3f,
            CardValue.Five => 2.5f,
            CardValue.Four => 2f,
            CardValue.Three => 1.5f,
            CardValue.Two => 1,
            _ => 0,
        };

        public Card(CardRank rank)
        {
            const int SUIT_OFFSET = 40;

            int rankValue = (int)rank;

            // Extracting the suit value
            int suitValue = Mathf.FloorToInt(rankValue / SUIT_OFFSET);
            suit = (CardSuit)(suitValue * SUIT_OFFSET);

            // Extracting the card value
            rankValue -= (suitValue * SUIT_OFFSET);
            value = (CardValue)rankValue;
        }

        public Card(CardSuit suit, CardValue value)
        {
            this.suit = suit;
            this.value = value;
        }

        public bool Equals(Card other) => value == other.value && suit == other.suit;

        public override string ToString() => $"{suit}:{value}";

        public static explicit operator Card(CardRank rank)
        {
            return new Card(rank);
        }
    }
}

namespace UnityPoker.Framework.Extensions
{
    public static partial class FrameworkExtensions
    {
        private static readonly int SUIT_LENGTH = 4;
        private static readonly int VALUE_LENGTH = 14;

        private static System.Random _R = new();

        public static int GetScore(this HandRank rank) => (int)rank;

        public static CardRank GetCardType(CardSuit suit, CardValue value) =>
            (CardRank)((byte)suit + (byte)value);

        public static T RandomEnumValue<T>()
        {
            var v = Enum.GetValues(typeof(T));
            return (T)v.GetValue(_R.Next(v.Length));
        }
    }
}
