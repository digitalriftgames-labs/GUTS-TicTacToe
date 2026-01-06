using GUTS.TicTacToe.Engine;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GUTS.TicTacToe.Unity
{
    public class GridButton : MonoBehaviour
    {
        private Button _button;
        private TMP_Text _buttonText;
        private Image _image;

        private void Awake()
        {
            _button = GetComponent<Button>();
            _buttonText = GetComponentInChildren<TMP_Text>();
            _image = GetComponent<Image>();
        }

        public void SetPlayer(Player player, bool? forceInteractable)
        {
            _buttonText.text = player switch
            {
                Player.X => "X",
                Player.O => "O",
                _ => "-"
            };

            if (forceInteractable.HasValue)
                _button.interactable = forceInteractable.Value;
            else
                _button.interactable = (player == Player.None);
        }

        public void SetHighlight(bool on)
        {
            _image.color = on ? Color.yellow : Color.white;
        }
    }
}
