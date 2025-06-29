using SolitaireUndo.Commands;

using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UndoButton : MonoBehaviour
    {
        [SerializeField]
        private Button _button;

        private void Awake()
        {
            _button.onClick.AddListener(OnClick);
        }

        private void OnDestroy()
        {
            _button.onClick.RemoveListener(OnClick);
        }

        private void OnClick()
        {
            CommandsExecutor.Instance.Undo();
        }
    }
}