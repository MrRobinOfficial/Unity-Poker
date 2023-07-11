//using NaughtyAttributes;
using UnityEngine;

namespace UnityPoker.Framework.Config
{
    [CreateAssetMenu(menuName = "Config/Game Config", fileName = "New Game Config")]
    public class GameConfig : ScriptableObject
    {
        public bool timeLimit = false;

        /// <summary>
        /// In seconds
        /// </summary>
        //[ShowIf(nameof(timeLimit))]
        public float timer = 600.0f; // 600 seconds -> 10 minutes
    }
}
