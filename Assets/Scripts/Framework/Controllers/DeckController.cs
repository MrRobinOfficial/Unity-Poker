using System.Collections.Generic;
using Extensions;
using UnityEngine;

namespace UnityPoker.Framework.Controllers
{
    public class DeckController : MonoBehaviour, IDeck
    {
        private const int DECK_LENGTH = 52;

        public static DeckController Instance { get; private set; } = null;

        private List<CardRank> m_Cards;

        [Header("References")]
        [SerializeField] private DeckData m_DeckData = null;

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
            {
                Destroy(gameObject);
                return;
            }

            DontDestroyOnLoad(Instance);
        }

        private void OnEnable()
        {
            m_Cards = new List<CardRank>(capacity: DECK_LENGTH);

            foreach (CardRank rank in System.Enum.GetValues(typeof(CardRank)))
            {
                if (rank == CardRank.Blank)
                    continue;

                m_Cards.Add(rank);
            }
        }

        public int GetCardCount() => m_Cards.Count;

        public IReadOnlyList<CardRank> GetAllCards() => m_Cards;

        public CardRank FetchRandomCard()
        {
            var rank = m_Cards.RandomItem();

            m_Cards.Remove(rank); // Remove from the deck

            return rank;
        }

        public Sprite GetCardSprite(CardRank card) => m_DeckData.GetSprite(card);
    }
}
