using Unity.Netcode;
using UnityEngine;
using UnityEngine.Events;

namespace UnityPoker.Framework.Controllers
{
    public class PlayerController : NetworkBehaviour
    {
        private NetworkList<Card> cards = new();

        public bool HasFolded => m_HasFolded;
        public string Username => m_Username;
        public int CurrentBet => m_CurrentBet;
        public bool IsReady => m_IsReady;

        private string m_Username;
        private bool m_HasFolded;
        private int m_CurrentBet;
        private bool m_IsReady = false;

        /// <summary>
        /// Calculate the score based on this <a href="https://www.thepokerbank.com/strategy/basic/starting-hand-selection/chen-formula/">article</a>
        /// </summary>
        /// <returns></returns>
        public float GetScore() => 0f;

        public void Fold()
        {
            if (!IsOwner)
                return;

            Fold_ServerRpc();
            OnFoldCallback();
        }

        private void OnFoldCallback()
        {

        }

        public override void OnNetworkSpawn()
        {

        }

        public override void OnNetworkDespawn()
        {

        }

        #region Network Handling

        [ServerRpc(Delivery = RpcDelivery.Reliable)]
        private void Fold_ServerRpc()
        {
            // Run server code

            m_HasFolded = true;

            Fold_ClientRpc();
        }

        [ClientRpc(Delivery = RpcDelivery.Reliable)]
        private void Fold_ClientRpc()
        {
            if (IsOwner)
                return;

            // Run client code

            OnFoldCallback();
        }

        #endregion
    }
}
