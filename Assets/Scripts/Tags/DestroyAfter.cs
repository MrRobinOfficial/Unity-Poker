using UnityEngine;

namespace UnityPoker.Tags
{
    /// <summary>
    /// Destroy the GameObject after X amount of seconds.
    /// </summary>
    [AddComponentMenu("Tags/DestroyAfter [Tag]")]
    public class DestroyAfter : MonoBehaviour
    {
        [SerializeField]
        private float m_DelayInSeconds = 3.0f;

        public float DelayInSeconds 
        {
            get => m_DelayInSeconds;
            set => m_DelayInSeconds = value;
        }

        private void Awake() => hideFlags = HideFlags.DontSave | HideFlags.NotEditable;

        private void Start() => Destroy(gameObject, DelayInSeconds);
    }
}
