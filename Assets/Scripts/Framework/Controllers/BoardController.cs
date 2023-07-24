using UnityEngine;

namespace UnityPoker.Framework.Controllers
{
    public class BoardController : MonoBehaviour
    {
        public static BoardController Instance { get; private set; } = null;

        public Vector3 MousePosition { get; private set; }

        [Header("Config")]
        [SerializeField] private Texture2D m_CursorTexture;

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
            {
                Destroy(gameObject);
                return;
            }

            DontDestroyOnLoad(Instance);
        }

        private void Start()
        {
            var cursorHotspot = new Vector2
            {
                x = m_CursorTexture.width / 2.0f,
                y = m_CursorTexture.height / 2.0f,
            };

            Cursor.SetCursor(m_CursorTexture, cursorHotspot, CursorMode.Auto);

            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
    }
}
