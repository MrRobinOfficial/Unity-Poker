using System.Collections.Generic;
using UnityEngine;

namespace UnityPoker.Framework
{
    public interface IDeck
    {
        public IReadOnlyList<CardRank> GetAllCards();

        public int GetCardCount();

        public CardRank FetchRandomCard();

        public Sprite GetCardSprite(CardRank card);
    }
}
