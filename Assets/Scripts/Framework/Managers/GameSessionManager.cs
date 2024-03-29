using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.Events;
using UnityPoker.Framework.Config;
using UnityPoker.Framework.Controllers;

namespace UnityPoker.Framework.Managers
{
    /// <summary>
    /// <see cref="GameSessionManager"/> is responsible to handle poker game.
    /// <para>Link to <a href="https://github.com/SaarSch/Texas_Holdem/blob/master/TexasHoldem/TexasHoldem/Game/Room.cs">room script</a></para>
    /// </summary>
    [AddComponentMenu("Framework/Managers/Game Session [Manager]")]
    public class GameSessionManager : MonoBehaviour
    {
        public enum SessionState
        {
            /// <summary>
            /// Waiting for the players to join
            /// </summary>
            Waiting,
            /// <summary>
            /// Bet before the 'game' begins
            /// </summary>
            PreFlop,
            /// <summary>
            /// 3 cards stage
            /// </summary>
            Flop,
            /// <summary>
            /// 4th card stage
            /// </summary>
            Turn,
            /// <summary>
            /// 5th card stage
            /// </summary>
            River,
            /// <summary>
            /// Calculate the finale result in this phase
            /// </summary>
            Finish,
        }

        private const int k_MinOfNumPlayers = 2;
        private const int k_MaxOfNumPlayers = 14;

        public static event UnityAction<SessionState> OnStateChanged;
        public static event UnityAction OnEveryoneIsReady;

        public static GameSessionManager Singleton { get; private set; } = null;

        public IReadOnlyList<PlayerController> Players => m_Players;
        public int CurrentPot => m_CurrentPot;
        public SessionState State => m_State;
        public IReadOnlyList<Card> Deck => m_Deck;
        public IReadOnlyList<Card> Dealer => m_Dealer;

        private List<Card> m_Deck = new(CardManager.k_MaxNumOfCards);
        private List<Card> m_Dealer = new(capacity: 5);

        private List<PlayerController> m_Players = new();
        private int m_CurrentPot;
        private SessionState m_State = SessionState.Waiting;
        private Coroutine m_SessionCoroutine;

        public void Init(GameConfig config)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="clientId"></param>
        /// <returns></returns>
        public bool HasPlayer(ulong clientId)
        {
            for (int i = 0; i < m_Players.Count; i++)
            {
                if (m_Players[i].OwnerClientId == clientId)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool CanJoin() => m_State == SessionState.Waiting;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool HasMinimumPlayers() => m_Players.Count > k_MinOfNumPlayers;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsEveryoneReady()
        {
            for (int i = 0; i < m_Players.Count; i++)
            {
                if (!m_Players[i].IsReady)
                    return false;
            }

            return m_Players.Count > 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int GetNumOfReadyPlayers()
        {
            int counter = 0;

            for (int i = 0; i < m_Players.Count; i++)
            {
                if (m_Players[i].IsReady)
                    counter++;
            }

            return counter;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int GetNumOfPlayers() => m_Players.Count;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="player"></param>
        public bool TryToJoin(PlayerController player)
        {
            if (!CanJoin())
                return false;

            if (m_Players.Contains(player))
                return false;

            m_Players.Add(player);
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="player"></param>
        public void Leave(PlayerController player)
        {
            if (!m_Players.Contains(player))
                return;

            m_Players.Remove(player);
        }

        private void Awake()
        {
            if (Singleton == null)
                Singleton = this;
            else
            {
                Destroy(gameObject);
                return;
            }

            DontDestroyOnLoad(gameObject);

            transform.hideFlags = HideFlags.HideInInspector;
            gameObject.hideFlags = HideFlags.NotEditable;
        }

        private void Start() => m_SessionCoroutine = StartCoroutine(LoadGame());

        private IEnumerator LoadGame()
        {
            Debug.Log("Starting!");

            m_State = SessionState.Waiting;
            OnStateChanged?.Invoke(m_State);

            while (m_State != SessionState.Finish)
            {
                yield return new WaitUntil(() => IsEveryoneReady());
                OnEveryoneIsReady?.Invoke();

                switch (m_State)
                {
                    case SessionState.Waiting:
                        yield return new WaitUntil(() =>
                        {
                            Debug.Log("Need at least 2 players, in-order to play.");

                            return HasMinimumPlayers();
                        });

                        m_State = SessionState.PreFlop;
                        OnStateChanged?.Invoke(m_State);
                        break;

                    case SessionState.PreFlop:
                        m_SessionCoroutine = StartCoroutine(PreFlop_Phase());
                        m_State = SessionState.Flop;
                        OnStateChanged?.Invoke(m_State);
                        break;

                    case SessionState.Flop:
                        m_SessionCoroutine = StartCoroutine(Flop_Phase());
                        m_State = SessionState.Turn;
                        OnStateChanged?.Invoke(m_State);
                        break;

                    case SessionState.Turn:
                        m_SessionCoroutine = StartCoroutine(Turn_Phase());
                        m_State = SessionState.River;
                        OnStateChanged?.Invoke(m_State);
                        break;

                    case SessionState.River:
                        m_SessionCoroutine = StartCoroutine(River_Phase());
                        m_State = SessionState.Finish;
                        OnStateChanged?.Invoke(m_State);
                        break;

                    case SessionState.Finish:

                        foreach (var player in m_Players)
                            player.Evaluate();

                        m_Players.Sort();

                        var winner = m_Players[0];
                        Debug.Log($"Winner: {winner.name}");

                        m_SessionCoroutine = null;
                        Clear();

                        break;
                }

                yield return null;
            }

            yield return new WaitForEndOfFrame();

            Debug.Log("Finished!");

            // Calculate the points
        }

        private IEnumerator PreFlop_Phase()
        {
            Debug.Log(nameof(PreFlop_Phase));

            foreach (var player in m_Players)
                DealCard(player, 2);

            yield return null;
        }

        private IEnumerator Flop_Phase()
        {
            Debug.Log(nameof(Flop_Phase));

            AddCardToDealer(3);

            foreach (var player in m_Players)
                player.Evaluate();

            yield return null;
        }

        private IEnumerator Turn_Phase()
        {
            Debug.Log(nameof(Turn_Phase));

            AddCardToDealer();

            foreach (var player in m_Players)
                player.Evaluate();

            yield return null;
        }

        private IEnumerator River_Phase()
        {
            Debug.Log(nameof(River_Phase));

            AddCardToDealer();

            foreach (var player in m_Players)
                player.Evaluate();

            yield return null;
        }

        private void Setup()
        {
            Clear();
            m_Deck = AppManager.CardManager.GenerateDeck();
        }

        private void Clear()
        {
            m_Deck.Clear();
            m_Dealer.Clear();
        }

        private void AddCardToDealer(int amount = 1)
        {
            for (int i = 0; i < amount; i++)
            {
                int index = Random.Range(0, m_Deck.Count);
                m_Dealer.Add(m_Deck[index]);
                m_Deck.RemoveAt(index);
            }
        }

        private void DealCard(PlayerController player, int amount = 1)
        {
            for (int i = 0; i < amount; i++)
            {
                int index = Random.Range(0, m_Deck.Count);
                player.AddCard(m_Deck[index]);
                m_Deck.RemoveAt(index);
            }

            player.Evaluate();
        }
    }
}
