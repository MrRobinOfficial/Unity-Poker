using UnityEditor;
using UnityEngine;

namespace UnityPoker.Tags.Editor
{
    public static partial class TagsEditorExtensions
    {
        [MenuItem("GameObject/Create TransitionTo",
            isValidateFunction: false, priority: -1)]
        public static void Create_TransitionTo()
        {
            var obj = new GameObject(name: "TransitionTo", typeof(TransitionTo));
            Selection.activeGameObject = obj;
        }
    }
}
