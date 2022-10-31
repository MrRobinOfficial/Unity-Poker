using Unity.Netcode;
using UnityEngine;

namespace UnityPoker.Framework.Controllers
{
    public class PlayerController : NetworkBehaviour
    {
        private NetworkList<Card> cards = new();

        /// <summary>
        /// Calculate the score based on this <a href="https://www.thepokerbank.com/strategy/basic/starting-hand-selection/chen-formula/">article</a>
        /// </summary>
        /// <returns></returns>
        public float GetScore() => 0f;

        public override void OnNetworkSpawn()
        {

        }

        public override void OnNetworkDespawn()
        {

        }
    }
}
