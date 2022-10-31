using System;
using System.Collections.Generic;
using Unity.VisualScripting.YamlDotNet.Core.Tokens;
using UnityEngine;

namespace UnityPoker.Framework.Managers
{
    /// <summary>
    /// <see cref="CardManager"/> is responsible to handle card system.
    /// </summary>
    [AddComponentMenu("Framework/Managers/Card [Manager]")]
    [RequireComponent(typeof(AppManager))]
    public class CardManager : MonoBehaviour
	{
        /// <summary>
        /// Creates a deck full of 52 playing cards
        /// </summary>
        /// <returns></returns>
        public List<Card> GenerateDeck()
        {
            var cards = new List<Card>(capacity: 52);

            foreach (CardSuit suit in System.Enum.GetValues(typeof(CardSuit)))
            {
                foreach (CardType type in System.Enum.GetValues(typeof(CardType)))
                {
                    cards.Add(new(suit, type));
                }
            }

            ShuffleDeck(cards);

            return cards;
        }

        /// <summary>
        /// Shuffle a deck of cards
        /// </summary>
        /// <param name="cards"></param>
        public void ShuffleDeck(List<Card> cards)
        {
            var rnd = new System.Random();

            for (var i = 0; i < cards.Count; i++)
                Swap(cards, i, rnd.Next(i, cards.Count));

            void Swap(List<Card> list, int i, int j) => 
                (list[j], list[i]) = (list[i], list[j]);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cards"></param>
        /// <param name="card"></param>
        /// <returns></returns>
        public bool TryToDrawCard(List<Card> cards, out Card card)
        {
            card = default;

            if (cards.Count < 1)
            {
                Debug.LogError(message: "Deck is empty, can't draw card");
                return false;
            }

            card = cards[0];
            cards.RemoveAt(0);
            return true;
 
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cards"></param>
        /// <param name="suit"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public bool HasCardInDeck(List<Card> cards, CardSuit suit, CardType type)
        {
            for (var i = 0; i < cards.Count; i++)
            {
                if (cards[i].suit == suit && cards[i].type == type)
                    return true;
            }

            return false;
        }
    }
}