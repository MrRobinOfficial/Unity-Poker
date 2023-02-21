using UnityEngine;
using UnityEngine.UIElements;

namespace UnityPoker.Framework
{
    public class DraggableController : MonoBehaviour
    {
        private Vector3 m_Offset;
        private float m_ZCoord;

        private void OnMouseDown()
        {
            m_ZCoord = Camera.main.WorldToScreenPoint(transform.position).z;
            m_Offset = transform.position - GetMouseWorldPosition();
        }

        private Vector3 GetMouseWorldPosition()
        {
            var mousePosition = Input.mousePosition;
            mousePosition.z = m_ZCoord;
            return Camera.main.ScreenToWorldPoint(mousePosition);
        }

        private void OnMouseDrag()
        {
            transform.position = GetMouseWorldPosition() + m_Offset;
        }
    }
}
