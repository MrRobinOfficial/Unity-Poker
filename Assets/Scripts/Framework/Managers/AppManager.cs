using UnityEngine;

namespace UnityPoker.Framework.Managers
{
    /// <summary>
    /// <see cref="AppManager"/> is responsible to connect bridge between all other managers and the app
    /// </summary>
    [AddComponentMenu("Framework/Managers/App [Manager]")]
    public class AppManager : MonoBehaviour
    {
        /// <summary>
        /// <see cref="AudioManager"/> is responsible to handle audio system.
        /// </summary>
        public static AudioManager AudioManager => m_AudioManager;

        /// <summary>
        /// <see cref="InputManager"/> is responsible to handle input system.
        /// </summary>
        public static InputManager InputManager => m_InputManager;

        /// <summary>
        /// <see cref="LevelManager"/> is responsible to handle level switching system.
        /// </summary>
        public static LevelManager LevelManager => m_LevelManager;

        /// <summary>
        /// <see cref="GameManager"/> is responsible to handle game system.
        /// </summary>
        public static GameManager GameManager => m_GameManager;

        /// <summary>
        /// <see cref="CardManager"/> is responsible to handle card system.
        /// </summary>
        public static CardManager CardManager => m_CardManager;

        [ContextMenu(itemName: "Quit", isValidateFunction: false, priority: 1000100)]
        public void Quit()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }

        private static AudioManager m_AudioManager = null;
        private static InputManager m_InputManager = null;
        private static LevelManager m_LevelManager = null;
        private static GameManager m_GameManager = null;
        private static CardManager m_CardManager = null;

        private void Awake() => Init();

        private void Start() => Init();

        private void Init()
        {
            TryGetComponent(out m_AudioManager);
            TryGetComponent(out m_InputManager);
            TryGetComponent(out m_LevelManager);
            TryGetComponent(out m_GameManager);
            TryGetComponent(out m_CardManager);
        }
    }
}
