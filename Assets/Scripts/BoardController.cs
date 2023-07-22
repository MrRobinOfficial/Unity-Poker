using UnityEngine;

namespace UnityPoker
{
    public class BoardController : MonoBehaviour
    {
        public static BoardController Instance { get; private set; } = null;

        public Vector3 MousePosition { get; private set; }

        [Header("Config")]
        [SerializeField] private LayerMask m_BoardMask;
        [SerializeField] private Texture2D m_CursorTexture;

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
            {
                Destroy(this.gameObject);
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

        private void FixedUpdate()
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit[] hits = Physics.RaycastAll(ray);

            for (int i = 0; i < hits.Length; i++)
            {
                if (((1 << hits[i].collider.gameObject.layer) & m_BoardMask) == 0)
                    continue;

                Debug.DrawLine(ray.origin, ray.origin + ray.direction * 100.0f, Color.red);

                MousePosition = hits[i].point;
                break;
            }
        }
    }
}
