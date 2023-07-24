using DG.Tweening.Core.Easing;
using System;
using System.Collections.Generic;
using Unity.Netcode;
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
        public const int k_MaxNumOfCards = 52;

        /// <summary>
        /// Creates a deck full of 52 playing cards
        /// </summary>
        /// <returns></returns>
        public List<Card> GenerateDeck()
        {
            var cards = new List<Card>(k_MaxNumOfCards);

            foreach (CardSuit suit in System.Enum.GetValues(typeof(CardSuit)))
            {
                foreach (CardValue value in System.Enum.GetValues(typeof(CardValue)))
                {
                    cards.Add(new(suit, value));
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
        public bool HasCardInDeck(List<Card> cards, CardSuit suit, CardValue value)
        {
            for (var i = 0; i < cards.Count; i++)
            {
                if (cards[i].suit == suit && cards[i].value == value)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cards"></param>
        /// <returns></returns>
        public HandRank Evaluate(NetworkList<Card> cards)
        {
            if (cards == null || cards.Count == 0)
                return HandRank.Fold;

            float valueScore = 0f;
            int suitScore = 0;

            foreach (var card in cards)
            {
                valueScore += card.GetValueScore();
                suitScore += card.GetSuitScore();
            }

            bool allHearts = suitScore == 4;
            bool allDiamonds = suitScore == 8;
            bool allSpades = suitScore == 12;
            bool allClubs = suitScore == 16;
            bool allSameSuit = allHearts || allDiamonds || allSpades || allClubs;

            if (allSameSuit)
            {
                if (valueScore == 36f)
                    return HandRank.RoyalFlush;
                else if (valueScore == 15f)
                    return HandRank.StraightFlush;
            }
            else
            {

            }

            return HandRank.Undefined;

            /**
             * Calculate hand score, based on card value and suit score.
             * Royal Flush = 0
             * Straight Flush = 0
             * Four Of AKind = 0
             * Full House = 0
             * Flush = 0
             * Straight = 0
             * Three Of AKind = 0
             * Two Pair = 0
             * One Pair = 0
             * High Card = 0
             */
        }
    }
}