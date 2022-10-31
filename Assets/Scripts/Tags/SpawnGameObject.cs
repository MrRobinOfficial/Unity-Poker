using UnityEngine;

namespace UnityPoker.Tags
{
    [AddComponentMenu("Tags/SpawnGameObject [Tag]")]
    public class SpawnGameObject : MonoBehaviour
    {
        private enum HandlingType
        {
            /// <summary>
            /// Client based
            /// </summary>
            Local,
            /// <summary>
            /// Server based
            /// </summary>
            Network
        }

        private enum SpawnType
        {
            /// <summary>
            /// Select the first element of the array
            /// </summary>
            Single,
            /// <summary>
            /// Select a random element of the array
            /// </summary>
            Random,
            /// <summary>
            /// Select all element of the array
            /// </summary>
            Array
        }

        [SerializeField] GameObject[] m_Prefabs = null;
        [SerializeField] SpawnType m_SpawnType = SpawnType.Single;
        [SerializeField] HandlingType m_HandlingType = HandlingType.Local;

        /// <summary>
        /// Destroy after spawn GameObject
        /// </summary>
        [SerializeField] bool m_DestroyAfter = true;

        private void Start()
        {
            switch (m_HandlingType)
            {
                case HandlingType.Local:
                    SpawnGameObject_Local();
                    break;

                case HandlingType.Network:
                    SpawnGameObject_Network();
                    break;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ContextMenu(nameof(SpawnGameObject_Local))]
        public void SpawnGameObject_Local()
        {
            switch (m_SpawnType)
            {
                case SpawnType.Single:
                    Instantiate(m_Prefabs[0]);
                    break;

                case SpawnType.Random:
                    int index = Random.Range(0, m_Prefabs.Length);
                    Instantiate(m_Prefabs[index]);
                    break;

                case SpawnType.Array:
                    for (int i = 0; i < m_Prefabs.Length; i++)
                        Instantiate(m_Prefabs[i]);
                    break;
            }

            if (m_DestroyAfter)
                Destroy(gameObject);
        }

        /// <summary>
        /// 
        /// </summary>
        [ContextMenu(nameof(SpawnGameObject_Network))]
        public void SpawnGameObject_Network() { }
    }
}
