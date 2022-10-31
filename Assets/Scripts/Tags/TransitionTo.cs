using UnityEngine;
using NaughtyAttributes;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityPoker.Framework.Managers;

namespace UnityPoker.Tags
{
    /// <summary>
    /// Transtion to a new level with parameter <see cref="LoadSceneMode"/>
    /// </summary>
    [AddComponentMenu("Tags/TransitionTo [Tag]")]
    public class TransitionTo : MonoBehaviour
    {
        public event UnityAction OnLoadCompleted;

        [SerializeField, Scene]
        private int m_SceneIndex = 0;

        [SerializeField]
        private LoadSceneMode m_SceneMode = LoadSceneMode.Single;

        [SerializeField]
        private bool m_AllowSceneActivation = true;

        [SerializeField]
        private UnityEvent m_OnLoadCompleted = null;

        public LoadSceneMode SceneMode
        {
            get => m_SceneMode;
            set => m_SceneMode = value;
        }
        public int SceneIndex
        {
            get => m_SceneIndex;
            set => m_SceneIndex = value;
        }
        public bool AllowSceneActivation
        {
            get => m_AllowSceneActivation;
            set => m_AllowSceneActivation = value;
        }

        private void Awake() => hideFlags = HideFlags.DontSave | HideFlags.NotEditable;

        private void Start() => AppManager.LevelManager.LoadLevelAsync(SceneIndex, SceneMode, AllowSceneActivation, Operation_completed);

        private void Operation_completed(AsyncOperation obj)
        {
            OnLoadCompleted?.Invoke();
            m_OnLoadCompleted?.Invoke();
        }
    }
}