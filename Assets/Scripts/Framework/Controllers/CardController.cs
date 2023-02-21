using UnityEngine;

namespace UnityPoker.Framework
{
    public class CardController : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] DeckData m_DeckData = null;
        [SerializeField] SpriteRenderer m_CardRenderer = null;

        [Header("Config")]
        [SerializeField] CardType m_CardType = CardType.Joker;

#if UNITY_EDITOR
        private void OnValidate()
        {
            if (m_DeckData == null)
                return;

            if (m_CardRenderer == null)
                return;

            m_CardRenderer.sprite = m_DeckData.GetSprite(m_CardType);
        }
#endif

        private void OnEnable()
        {
            if (m_DeckData == null)
                return;

            if (m_CardRenderer == null)
                return;

            m_CardRenderer.sprite = m_DeckData.GetSprite(m_CardType);
        }
    }
}
