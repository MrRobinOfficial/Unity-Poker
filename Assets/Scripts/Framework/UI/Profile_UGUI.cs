using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UnityPoker.Framework.UI
{
    /// <summary>
    /// <see cref="Profile_UGUI"/> is responsible to handling profile UI.
    /// </summary>
    [AddComponentMenu("Framework/Managers/Profile [UGUI]")]
    public class Profile_UGUI : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] Image m_Icon;
        [SerializeField] TextMeshProUGUI m_DisplayNameText;

        public void Init(string displayName, Sprite icon)
        {
            m_DisplayNameText.SetText(displayName);
            m_Icon.sprite = icon;
        }
    }
}
