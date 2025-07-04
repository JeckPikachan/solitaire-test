using System.Collections.Generic;
using System.Linq;

using UnityEngine;

namespace SolitaireUndo.CardGame
{
    public class CardStack : MonoBehaviour
    {
        private List<Card> _cards = new();

        private void Awake()
        {
            _cards = GetComponentsInChildren<Card>().ToList();
            foreach (Card card in _cards)
            {
                card.SetStack(this);
            }
            
            _cards[^1].SetFaceUp(true);
        }

        public void AddCard(Card card)
        {
            _cards.Add(card);
            card.SetStack(this);
        }

        public void RemoveCard(Card card)
        {
            _cards.Remove(card);
        }
        
        public List<Card> GetCardsFrom(Card startingCard)
        {
            int index = _cards.IndexOf(startingCard);
            if (index == -1) return new List<Card>();
            return _cards.GetRange(index, _cards.Count - index);
        }

        public Card GetLastCard()
        {
            return _cards.Count > 0 ? _cards[^1] : null;
        }
    }
}