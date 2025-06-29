using UnityEngine;
using UnityEngine.UI;

namespace SolitaireUndo.CardGame
{
    public class Card : MonoBehaviour
    {
        [SerializeField]
        private Sprite _backFace;
        [SerializeField]
        private Sprite _frontFace;

        [SerializeField]
        private Image _faceImage;
        
        private bool _faceUp;
        private CardStack _currentStack;

        public bool FaceUp => _faceUp;
        public CardStack CurrentStack => _currentStack;

        public void SetFaceUp(bool faceUp)
        {
            _faceUp = faceUp;
            _faceImage.sprite = faceUp ? _frontFace : _backFace;
        }

        public void SetStack(CardStack stack)
        {
            _currentStack = stack;
            transform.SetParent(stack.transform);
        }
    }
}

