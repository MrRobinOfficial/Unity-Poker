using UnityEngine;

namespace UnityPoker
{
    [RequireComponent (typeof(Rigidbody))]
    public class DraggableObject : MonoBehaviour
    {
        [Header("Dragging Config")]
        [SerializeField] private float m_DragVelocity = 10.0f;
        [SerializeField, Range(0.0f, 5.0f)] private float m_DragOffset = 1.0f;

        [Header("Config")]
        [SerializeField] private float m_Mass = 1.0f;
        [SerializeField] private float m_Drag = 0.0f;
        [SerializeField] private float m_AngularDrag = 3.0f;
        [SerializeField] private RigidbodyInterpolation m_Interpolation = RigidbodyInterpolation.Interpolate;

        private Rigidbody m_Rigidbody = null;

        private float m_StartYPos;

        private void Awake()
        {
            m_Rigidbody = GetComponent<Rigidbody>();
        }

        private void Start()
        {
            m_Rigidbody.mass = m_Mass;
            m_Rigidbody.drag = m_Drag;
            m_Rigidbody.angularDrag = m_AngularDrag;
            m_Rigidbody.useGravity = true;
            m_Rigidbody.interpolation = m_Interpolation;
            m_Rigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;

            m_StartYPos = 0;
        }

        private void OnMouseDrag()
        {
            var mousePosition = BoardController.Instance.MousePosition;

            Vector3 newPosition = new Vector3
            {
                x = mousePosition.x,
                y = m_StartYPos + m_DragOffset,
                z = mousePosition.z
            };

            var diff = newPosition - transform.position;

            m_Rigidbody.velocity = m_DragVelocity * diff;
            m_Rigidbody.rotation = Quaternion.Euler(new Vector3(m_Rigidbody.velocity.z, 0.0f, m_Rigidbody.velocity.x));
        }
    }
}
