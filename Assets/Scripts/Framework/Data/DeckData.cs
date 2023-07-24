using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Serialization;

namespace UnityPoker.Framework
{
    [CreateAssetMenu(menuName = "Data/Deck", fileName = "New Deck Data")]
    public class DeckData : ScriptableObject
    {
        [Foldout("Misc")]
        [FormerlySerializedAs("joker")]
        public Sprite blank;

        [Foldout("Clubs")]
        public Sprite clubsAce;

        [Foldout("Clubs")]
        public Sprite clubsTwo;

        [Foldout("Clubs")]
        public Sprite clubsThree;

        [Foldout("Clubs")]
        public Sprite clubsFour;

        [Foldout("Clubs")]
        public Sprite clubsFive;

        [Foldout("Clubs")]
        public Sprite clubsSix;

        [Foldout("Clubs")]
        public Sprite clubsSeven;

        [Foldout("Clubs")]
        public Sprite clubsEight;

        [Foldout("Clubs")]
        public Sprite clubsNine;

        [Foldout("Clubs")]
        public Sprite clubsTen;

        [Foldout("Clubs")]
        public Sprite clubsJack;

        [Foldout("Clubs")]
        public Sprite clubsQueen;

        [Foldout("Clubs")]
        public Sprite clubsKing;

        [Foldout("Diamonds")]
        public Sprite diamondsAce;

        [Foldout("Diamonds")]
        public Sprite diamondsTwo;

        [Foldout("Diamonds")]
        public Sprite diamondsThree;

        [Foldout("Diamonds")]
        public Sprite diamondsFour;

        [Foldout("Diamonds")]
        public Sprite diamondsFive;

        [Foldout("Diamonds")]
        public Sprite diamondsSix;

        [Foldout("Diamonds")]
        public Sprite diamondsSeven;

        [Foldout("Diamonds")]
        public Sprite diamondsEight;

        [Foldout("Diamonds")]
        public Sprite diamondsNine;

        [Foldout("Diamonds")]
        public Sprite diamondsTen;

        [Foldout("Diamonds")]
        public Sprite diamondsJack;

        [Foldout("Diamonds")]
        public Sprite diamondsQueen;

        [Foldout("Diamonds")]
        public Sprite diamondsKing;

        [Foldout("Hearts")]
        public Sprite heartsAce;

        [Foldout("Hearts")]
        public Sprite heartsTwo;

        [Foldout("Hearts")]
        public Sprite heartsThree;

        [Foldout("Hearts")]
        public Sprite heartsFour;

        [Foldout("Hearts")]
        public Sprite heartsFive;

        [Foldout("Hearts")]
        public Sprite heartsSix;

        [Foldout("Hearts")]
        public Sprite heartsSeven;

        [Foldout("Hearts")]
        public Sprite heartsEight;

        [Foldout("Hearts")]
        public Sprite heartsNine;

        [Foldout("Hearts")]
        public Sprite heartsTen;

        [Foldout("Hearts")]
        public Sprite heartsJack;

        [Foldout("Hearts")]
        public Sprite heartsQueen;

        [Foldout("Hearts")]
        public Sprite heartsKing;

        [Foldout("Spades")]
        public Sprite spadesAce;

        [Foldout("Spades")]
        public Sprite spadesTwo;

        [Foldout("Spades")]
        public Sprite spadesThree;

        [Foldout("Spades")]
        public Sprite spadesFour;

        [Foldout("Spades")]
        public Sprite spadesFive;

        [Foldout("Spades")]
        public Sprite spadesSix;

        [Foldout("Spades")]
        public Sprite spadesSeven;

        [Foldout("Spades")]
        public Sprite spadesEight;

        [Foldout("Spades")]
        public Sprite spadesNine;

        [Foldout("Spades")]
        public Sprite spadesTen;

        [Foldout("Spades")]
        public Sprite spadesJack;

        [Foldout("Spades")]
        public Sprite spadesQueen;

        [Foldout("Spades")]
        public Sprite spadesKing;

        public Sprite GetSprite(CardRank cardType) => cardType switch
        {
            CardRank.Blank => blank,
            CardRank.Spade_Ace => spadesAce,
            CardRank.Spade_Two => spadesTwo,
            CardRank.Spade_Three => spadesThree,
            CardRank.Spade_Four => spadesFour,
            CardRank.Spade_Five => spadesFive,
            CardRank.Spade_Six => spadesSix,
            CardRank.Spade_Seven => spadesSeven,
            CardRank.Spade_Eight => spadesEight,
            CardRank.Spade_Nine => spadesNine,
            CardRank.Spade_Ten => spadesTen,
            CardRank.Spade_Jack => spadesJack,
            CardRank.Spade_Queen => spadesQueen,
            CardRank.Spade_King => spadesKing,
            CardRank.Hearts_Ace => heartsAce,
            CardRank.Hearts_Two => heartsTwo,
            CardRank.Hearts_Three => heartsThree,
            CardRank.Hearts_Four => heartsFour,
            CardRank.Hearts_Five => heartsFive,
            CardRank.Hearts_Six => heartsSix,
            CardRank.Hearts_Seven => heartsSeven,
            CardRank.Hearts_Eight => heartsEight,
            CardRank.Hearts_Nine => heartsNine,
            CardRank.Hearts_Ten => heartsTen,
            CardRank.Hearts_Jack => heartsJack,
            CardRank.Hearts_Queen => heartsQueen,
            CardRank.Hearts_King => heartsKing,
            CardRank.Diamonds_Ace => diamondsAce,
            CardRank.Diamonds_Two => diamondsTwo,
            CardRank.Diamonds_Three => diamondsThree,
            CardRank.Diamonds_Four => diamondsFour,
            CardRank.Diamonds_Five => diamondsFive,
            CardRank.Diamonds_Six => diamondsSix,
            CardRank.Diamonds_Seven => diamondsSeven,
            CardRank.Diamonds_Eight => diamondsEight,
            CardRank.Diamonds_Nine => diamondsNine,
            CardRank.Diamonds_Ten => diamondsTen,
            CardRank.Diamonds_Jack => diamondsJack,
            CardRank.Diamonds_Queen => diamondsQueen,
            CardRank.Diamonds_King => diamondsKing,
            CardRank.Clubs_Ace => clubsAce,
            CardRank.Clubs_Two => clubsTwo,
            CardRank.Clubs_Three => clubsThree,
            CardRank.Clubs_Four => clubsFour,
            CardRank.Clubs_Five => clubsFive,
            CardRank.Clubs_Six => clubsSix,
            CardRank.Clubs_Seven => clubsSeven,
            CardRank.Clubs_Eight => clubsEight,
            CardRank.Clubs_Nine => clubsNine,
            CardRank.Clubs_Ten => clubsTen,
            CardRank.Clubs_Jack => clubsJack,
            CardRank.Clubs_Queen => clubsQueen,
            CardRank.Clubs_King => clubsKing,
            _ => throw new System.NotImplementedException(),
        };
    }
}
