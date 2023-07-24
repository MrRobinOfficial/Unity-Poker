using UnityEngine;
using UnityEngine.Assertions;
using UnityPoker.Framework.Extensions;

namespace UnityPoker.Framework.Controllers
{
    public class CardController : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] SpriteRenderer m_CardRenderer = null;

        private CardRank m_CardRank;

        private void OnEnable()
        {
            if (m_CardRenderer == null)
                return;

            Assert.IsNotNull(BoardController.Instance, "BoardController cannot be null!");

            IDeck deck = DeckController.Instance;

            m_CardRank = deck.FetchRandomCard();
            m_CardRenderer.sprite = deck.GetCardSprite(m_CardRank);

            Card card = (Card)m_CardRank;

            //m_HandRank = AppManager.CardManager.Evaluate(m_Cards);

            //FrameworkExtensions.GetScore();

            Debug.Log($"{card.suit}: {card.value}");
        }
    }
}
