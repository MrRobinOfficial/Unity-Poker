using UnityEngine;

namespace UnityPoker.Framework
{
    [CreateAssetMenu(menuName = "Data/Deck", fileName = "New Deck Data")]
    public class DeckData : ScriptableObject
    {
        public Sprite joker;
        public Sprite back;
        public Sprite backAlt;

        public Sprite clubsAce;
        public Sprite clubsTwo;
        public Sprite clubsThree;
        public Sprite clubsFour;
        public Sprite clubsFive;
        public Sprite clubsSix;
        public Sprite clubsSeven;
        public Sprite clubsEight;
        public Sprite clubsNine;
        public Sprite clubsTen;
        public Sprite clubsJack;
        public Sprite clubsQueen;
        public Sprite clubsKing;

        public Sprite diamondsAce;
        public Sprite diamondsTwo;
        public Sprite diamondsThree;
        public Sprite diamondsFour;
        public Sprite diamondsFive;
        public Sprite diamondsSix;
        public Sprite diamondsSeven;
        public Sprite diamondsEight;
        public Sprite diamondsNine;
        public Sprite diamondsTen;
        public Sprite diamondsJack;
        public Sprite diamondsQueen;
        public Sprite diamondsKing;

        public Sprite heartsAce;
        public Sprite heartsTwo;
        public Sprite heartsThree;
        public Sprite heartsFour;
        public Sprite heartsFive;
        public Sprite heartsSix;
        public Sprite heartsSeven;
        public Sprite heartsEight;
        public Sprite heartsNine;
        public Sprite heartsTen;
        public Sprite heartsJack;
        public Sprite heartsQueen;
        public Sprite heartsKing;

        public Sprite spadesAce;
        public Sprite spadesTwo;
        public Sprite spadesThree;
        public Sprite spadesFour;
        public Sprite spadesFive;
        public Sprite spadesSix;
        public Sprite spadesSeven;
        public Sprite spadesEight;
        public Sprite spadesNine;
        public Sprite spadesTen;
        public Sprite spadesJack;
        public Sprite spadesQueen;
        public Sprite spadesKing;

        public Sprite GetSprite(CardType cardType) => cardType switch
        {
            CardType.Joker => joker,
            CardType.Spade_Ace => spadesAce,
            CardType.Spade_Two => spadesTwo,
            CardType.Spade_Three => spadesThree,
            CardType.Spade_Four => spadesFour,
            CardType.Spade_Five => spadesFive,
            CardType.Spade_Six => spadesSix,
            CardType.Spade_Seven => spadesSeven,
            CardType.Spade_Eight => spadesEight,
            CardType.Spade_Nine => spadesNine,
            CardType.Spade_Ten => spadesTen,
            CardType.Spade_Jack => spadesJack,
            CardType.Spade_Queen => spadesQueen,
            CardType.Spade_King => spadesKing,
            CardType.Hearts_Ace => heartsAce,
            CardType.Hearts_Two => heartsTwo,
            CardType.Hearts_Three => heartsThree,
            CardType.Hearts_Four => heartsFour,
            CardType.Hearts_Five => heartsFive,
            CardType.Hearts_Six => heartsSix,
            CardType.Hearts_Seven => heartsSeven,
            CardType.Hearts_Eight => heartsEight,
            CardType.Hearts_Nine => heartsNine,
            CardType.Hearts_Ten => heartsTen,
            CardType.Hearts_Jack => heartsJack,
            CardType.Hearts_Queen => heartsQueen,
            CardType.Hearts_King => heartsKing,
            CardType.Diamonds_Ace => diamondsAce,
            CardType.Diamonds_Two => diamondsTwo,
            CardType.Diamonds_Three => diamondsThree,
            CardType.Diamonds_Four => diamondsFour,
            CardType.Diamonds_Five => diamondsFive,
            CardType.Diamonds_Six => diamondsSix,
            CardType.Diamonds_Seven => diamondsSeven,
            CardType.Diamonds_Eight => diamondsEight,
            CardType.Diamonds_Nine => diamondsNine,
            CardType.Diamonds_Ten => diamondsTen,
            CardType.Diamonds_Jack => diamondsJack,
            CardType.Diamonds_Queen => diamondsQueen,
            CardType.Diamonds_King => diamondsKing,
            CardType.Clubs_Ace => clubsAce,
            CardType.Clubs_Two => clubsTwo,
            CardType.Clubs_Three => clubsThree,
            CardType.Clubs_Four => clubsFour,
            CardType.Clubs_Five => clubsFive,
            CardType.Clubs_Six => clubsSix,
            CardType.Clubs_Seven => clubsSeven,
            CardType.Clubs_Eight => clubsEight,
            CardType.Clubs_Nine => clubsNine,
            CardType.Clubs_Ten => clubsTen,
            CardType.Clubs_Jack => clubsJack,
            CardType.Clubs_Queen => clubsQueen,
            CardType.Clubs_King => clubsKing,
            _ => throw new System.NotImplementedException(),
        };
    }
}
