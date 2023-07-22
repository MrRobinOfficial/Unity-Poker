﻿using System;

namespace Tools.UI.Card
{
    //------------------------------------------------------------------------------------------------------------------

    /// <summary>
    ///     The Player Hand.
    /// </summary>
    public class UiPlayerHand : UiCardPile, IUiPlayerHand
    {
        //--------------------------------------------------------------------------------------------------------------

        #region Properties

        /// <summary>
        ///     Card currently selected by the player.
        /// </summary>
        public IUiCard SelectedCard { get; private set; }

        event Action<IUiCard> OnCardSelected = card => { };

        event Action<IUiCard> OnCardPlayed = card => { };

        /// <summary>
        ///     Event raised when a card is played.
        /// </summary>
        Action<IUiCard> IUiPlayerHand.OnCardPlayed
        {
            get => OnCardPlayed;
            set => OnCardPlayed = value;
        }

        /// <summary>
        ///     Event raised when a card is selected.
        /// </summary>
        Action<IUiCard> IUiPlayerHand.OnCardSelected
        {
            get => OnCardSelected;
            set => OnCardSelected = value;
        }

        #endregion

        //--------------------------------------------------------------------------------------------------------------

        #region Operations

        /// <summary>
        ///     Select the card in the parameter.
        /// </summary>
        /// <param name="card"></param>
        public void SelectCard(IUiCard card)
        {
            SelectedCard = card ?? throw new ArgumentNullException("Null is not a valid argument.");

            //disable all cards
            DisableCards();
            NotifyCardSelected();
        }

        /// <summary>
        ///     Play the card which is currently selected. Nothing happens if current is null.
        /// </summary>
        /// <param name="card"></param>
        public void PlaySelected()
        {
            if (SelectedCard == null)
                return;

            PlayCard(SelectedCard);
        }

        /// <summary>
        ///     Play the card in the parameter.
        /// </summary>
        /// <param name="card"></param>
        public void PlayCard(IUiCard card)
        {
            if (card == null)
                throw new ArgumentNullException("Null is not a valid argument.");

            SelectedCard = null;
            RemoveCard(card);
            OnCardPlayed?.Invoke(card);
            EnableCards();
            NotifyPileChange();
        }

        /// <summary>
        ///     Unselect the card in the parameter.
        /// </summary>
        /// <param name="card"></param>
        public void UnselectCard(IUiCard card)
        {
            if (card == null)
                return;

            SelectedCard = null;
            card.Unselect();
            NotifyPileChange();
            EnableCards();
        }

        /// <summary>
        ///     Unselect the card which is currently selected. Nothing happens if current is null.
        /// </summary>
        public void Unselect() => UnselectCard(SelectedCard);

        /// <summary>
        ///     Disables input for all cards.
        /// </summary>
        public void DisableCards()
        {
            foreach (var otherCard in Cards)
                otherCard.Disable();
        }

        /// <summary>
        ///     Enables input for all cards.
        /// </summary>
        public void EnableCards()
        {
            foreach (var otherCard in Cards)
                otherCard.Enable();
        }

        [Button]
        void NotifyCardSelected() => OnCardSelected?.Invoke(SelectedCard);

        #endregion
    }
}