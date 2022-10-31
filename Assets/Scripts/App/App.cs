using UnityEditor;
using UnityEditor.PackageManager.Requests;
using UnityEngine;

namespace UnityPoker.App
{
    /// <summary>
    /// <see cref="App"/> is responsible to initalizes game and redirect to next phase.
    /// </summary>
    public static partial class App
    {
        public const string k_Name = "__APP__";

        private static ResourceRequest appRequest;
        private const string k_AppPath = "Prefabs/App";

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        private static void Bootstrap()
        {
            appRequest = Resources.LoadAsync<GameObject>(k_AppPath);
            appRequest.allowSceneActivation = false;
            appRequest.completed += App_completed;
        }

        private static void App_completed(AsyncOperation ctx)
        {
            appRequest.completed -= App_completed;

            var obj = Object.Instantiate((GameObject)appRequest.asset);

#if UNITY_EDITOR
            EditorGUIUtility.PingObject(obj);
#endif

            obj.transform.hideFlags = HideFlags.HideInInspector;
            obj.name = k_Name;
            obj.SetActive(true);
        }
    }

}