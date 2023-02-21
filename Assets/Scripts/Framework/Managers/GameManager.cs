using UnityEngine;
using UnityPoker.Framework.Config;

namespace UnityPoker.Framework.Managers
{
    /// <summary>
    /// <see cref="GameManager"/> is responsible to handle game system.
    /// </summary>
    [AddComponentMenu("Framework/Managers/Game [Manager]")]
    [RequireComponent(typeof(AppManager))]
    public class GameManager : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] GameConfig m_Config = null;

        private ResourceRequest m_ResourceRequest;

        [ContextMenu(itemName: "Start Session", 
            isValidateFunction: false, priority: 1000100)]
        public void StartSession()
        {
            m_ResourceRequest = Resources.LoadAsync<GameObject>("GameSession");
            m_ResourceRequest.allowSceneActivation = true;
            m_ResourceRequest.completed += Request_completed;
        }

        private void Request_completed(AsyncOperation ctx)
        {
            m_ResourceRequest.completed -= Request_completed;

            var obj = Instantiate((GameObject)m_ResourceRequest.asset);
            var manager = obj.GetComponent<GameSessionManager>();

            manager.Init(m_Config);
        }

        public void StopSession()
        {

        }
    }
}