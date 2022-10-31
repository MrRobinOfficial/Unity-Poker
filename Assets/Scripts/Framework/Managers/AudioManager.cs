using UnityEngine;

namespace UnityPoker.Framework.Managers
{
    /// <summary>
    /// <see cref="AudioManager"/> is responsible to handle audio system.
    /// </summary>
    [AddComponentMenu("Framework/Managers/Audio [Manager]")]
    [RequireComponent(typeof(AppManager))]
    public class AudioManager : MonoBehaviour
    {
        [SerializeField, Range(0.0f, 1.0f)]
        private float m_MasterVolume = 1.0f;

        public float MasterVolume
        {
            get => m_MasterVolume;
            set => m_MasterVolume = Mathf.Clamp01(value);
        }
    }
}