using UnityEngine;

namespace UnityPoker.Tags
{
    [AddComponentMenu("Tags/DontDestroyOnLoad [Tag]")]
    public class DontDestroyOnLoad : MonoBehaviour
	{
		private void Awake() => hideFlags = HideFlags.DontSave | HideFlags.NotEditable;

		private void Start() => DontDestroyOnLoad(gameObject);
	}

}