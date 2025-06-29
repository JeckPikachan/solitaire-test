using System.Collections.Generic;

using UnityEngine;
using UnityEngine.EventSystems;

namespace SolitaireUndo
{
    public class CardDragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        private Vector3 startPosition;
        private Transform originalParent;
        private CanvasGroup canvasGroup;
        private Card card;
        private Canvas canvas;

        void Awake()
        {
            card = GetComponent<Card>();
            canvasGroup = GetComponent<CanvasGroup>();
            canvas = GetComponentInParent<Canvas>();
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            if (!card.FaceUp) return;

            startPosition = transform.position;
            originalParent = transform.parent;
            transform.SetParent(canvas.transform);
            // canvasGroup.blocksRaycasts = false;
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (!card.FaceUp) return;
            
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
                    canvas.transform as RectTransform,
                    eventData.position,
                    canvas.worldCamera,
                    out Vector2 localPoint))
            {
                transform.localPosition = localPoint;
            }
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            // canvasGroup.blocksRaycasts = true;

            List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventData, results);

            foreach (RaycastResult result in results)
            {
                var targetStack = result.gameObject.GetComponent<CardStack>();
                if (targetStack != null)
                {
                    card.CurrentStack.RemoveCard(card);
                    targetStack.AddCard(card);
                    return;
                }
            }

            // Snap back if no valid drop
            transform.position = startPosition;
            transform.SetParent(originalParent);
        }
    }
}