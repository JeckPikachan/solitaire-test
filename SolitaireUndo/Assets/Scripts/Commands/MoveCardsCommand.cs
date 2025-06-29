using System;
using System.Collections.Generic;

using SolitaireUndo.CardGame;

namespace SolitaireUndo.Commands
{
    public class MoveCardsCommand : ICommand
    {
        private readonly List<Card> _draggedCards;
        private readonly CardStack _targetStack;
        private readonly CardStack _initialStack;

        private bool _didRotateLastCard;

        public MoveCardsCommand(List<Card> draggedCards, CardStack targetStack)
        {
            if (draggedCards == null || draggedCards.Count == 0)
            {
                throw new ArgumentException("Empty cards list");
            }
            
            // Clone list of cards
            _draggedCards = new();
            foreach (var card in draggedCards)
            {
                _draggedCards.Add(card);
            }
            
            _targetStack = targetStack;
            _initialStack = _draggedCards[0].CurrentStack;
        }
        
        public void Do()
        {
            foreach (Card card in _draggedCards)
            {
                card.CurrentStack.RemoveCard(card);
                _targetStack.AddCard(card);
            }

            Card lastCard = _initialStack.GetLastCard();
            if (lastCard is not null && !lastCard.FaceUp)
            {
                lastCard.SetFaceUp(true);
                _didRotateLastCard = true;
            }
        }

        public void Undo()
        {
            var lastCard = _initialStack.GetLastCard();
            if (lastCard is not null && _didRotateLastCard)
            {
                lastCard.SetFaceUp(false);
            }
            
            foreach (Card card in _draggedCards)
            {
                _targetStack.RemoveCard(card);
                _initialStack.AddCard(card);
            }
        }
    }
}