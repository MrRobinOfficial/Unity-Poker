using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

namespace UnityPoker.Framework.Managers
{
    /// <summary>
    /// <see cref="LevelManager"/> is responsible to handle level switching system.
    /// </summary>
    [AddComponentMenu("Framework/Managers/Level [Manager]")]
    [RequireComponent(typeof(AppManager))]
    public class LevelManager : MonoBehaviour
    {
        public void LoadLevelAsync(int sceneIndex, LoadSceneMode sceneMode,
            bool allowSceneActivation, System.Action<AsyncOperation> callback = null)
        {
            var operation = SceneManager.LoadSceneAsync(sceneIndex, sceneMode);
            operation.allowSceneActivation = allowSceneActivation;
            operation.completed += callback;
        }
    } 
}
