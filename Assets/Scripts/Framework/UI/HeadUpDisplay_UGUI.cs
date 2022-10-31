using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityPoker.Framework.Managers;

using Manager = UnityPoker.Framework.Managers.GameSessionManager;

namespace UnityPoker.Framework.UI
{
    /// <summary>
    /// <see cref="HeadUpDisplay_UGUI"/> is responsible to handle poker game UI stuff. Such as points, players and stage.
    /// </summary>
    [AddComponentMenu("Framework/Managers/HUD [UGUI]")]
    public class HeadUpDisplay_UGUI : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI m_StateText;
        [SerializeField] TextMeshProUGUI m_ReadyCounterText;

        private void Awake()
        {
            Manager.OnStateChanged += OnStateChanged;
            Manager.OnEveryoneIsReady += OnEveryoneIsReady;
        }

        private void OnDestroy()
        {
            Manager.OnStateChanged -= OnStateChanged;
            Manager.OnEveryoneIsReady -= OnEveryoneIsReady;
        }

        private void LateUpdate()
        {
            var numOfReadyPlayers = Manager.Singleton.GetNumOfReadyPlayers();
            var numOfPlayers = Manager.Singleton.GetNumOfPlayers();

            m_ReadyCounterText.SetText("Ready: {0}/{1}", numOfReadyPlayers, numOfPlayers);
        }

        private void OnStateChanged(Manager.SessionState newState) => m_StateText.SetText(newState.ToString());

        private void OnEveryoneIsReady()
        {
            throw new System.NotImplementedException();
        }
    }
}
