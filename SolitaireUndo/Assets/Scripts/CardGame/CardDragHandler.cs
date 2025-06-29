using System.Collections.Generic;

using SolitaireUndo.Commands;

using UnityEngine;
using UnityEngine.EventSystems;

namespace SolitaireUndo.CardGame
{
    public class CardDragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        private Vector3 _startPosition;
        private Card _card;
        private Canvas _canvas;
        
        private List<Card> _draggedCards = new();
        private readonly List<Vector3> _cardOffsets = new();

        void Awake()
        {
            _card = GetComponent<Card>();
            _canvas = GetComponentInParent<Canvas>();
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            if (!_card.FaceUp) return;

            _startPosition = transform.position;
            
            _draggedCards = _card.CurrentStack.GetCardsFrom(_card);

            foreach (Card draggedCard in _draggedCards)
            {
                _cardOffsets.Add(draggedCard.transform.position - _startPosition);
            }
            
            foreach (Card card in _draggedCards)
            {
                card.transform.SetParent(_canvas.transform);
            }
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (!_card.FaceUp) return;
            
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
                    _canvas.transform as RectTransform,
                    eventData.position,
                    _canvas.worldCamera,
                    out Vector2 localPoint))
            {
                Vector3 basePos = _canvas.transform.TransformPoint(localPoint);
                for (int i = 0; i < _draggedCards.Count; i++)
                {
                    _draggedCards[i].transform.position = basePos + _cardOffsets[i]; // stack offset
                }
            }
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventData, results);

            CardStack targetStack = null;
            foreach (RaycastResult result in results)
            {
                var stack = result.gameObject.GetComponent<CardStack>();
                if (stack != null)
                { 
                    targetStack = stack;
                    break;
                }
            }
            
            if (targetStack != null)
            {
                var moveCommand = new MoveCardsCommand(_draggedCards, targetStack);
                CommandsExecutor.Instance.Execute(moveCommand);
            }
            else
            {
                // Snap back
                foreach (Card card in _draggedCards)
                {
                    card.transform.SetParent(_card.CurrentStack.transform);
                }
            }

            _draggedCards.Clear();
            _cardOffsets.Clear();
        }
    }
}