using System;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityPoker.Framework.Extensions;
using UnityPoker.Framework.Managers;

namespace UnityPoker.Framework.Controllers
{
    [RequireComponent(typeof(PlayerInput))]
    public class PlayerController : NetworkBehaviour, IComparable<PlayerController>
    {
        public event UnityAction<HandRankType> OnEvaluated;

        private NetworkList<Card> m_Cards = new();

        public bool HasFolded => m_HasFolded;
        public string Username => m_Username;
        public int CurrentBet => m_CurrentBet;
        public bool IsReady => m_IsReady;
        public HandRankType HandRank => m_HandRank;

        private string m_Username;
        private bool m_HasFolded;
        private int m_CurrentBet;
        private bool m_IsReady = false;
        private HandRankType m_HandRank = HandRankType.RoyalFlush;

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

        private PlayerInput input;

        private void Awake()
        {
            input = GetComponent<PlayerInput>();
        }

        private void OnEnable()
        {
            if (!IsOwner)
                return;

            input.ActivateInput();
        }

        private void OnDisable()
        {
            if (!IsOwner)
                return;

            input.DeactivateInput();
        }

        public override void OnNetworkSpawn()
        {

        }

        public override void OnNetworkDespawn()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="card"></param>
        public void AddCard(Card card) => m_Cards.Add(card);

        public HandRankType Evaluate()
        {
            m_HandRank = AppManager.CardManager.Evaluate(m_Cards);
            OnEvaluated?.Invoke(m_HandRank);
            return m_HandRank;
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

        public int CompareTo(PlayerController other) => 
            HandRank.CompareTo(other.HandRank) * -1;

        #endregion
    }
}
