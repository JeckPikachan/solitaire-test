using System;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

namespace SolitaireUndo
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
            if (_cards.Count != 0)
            {
                _cards[^1].SetFaceUp(true);
            }
        }
    }
}