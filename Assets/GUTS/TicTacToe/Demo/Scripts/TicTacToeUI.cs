using GUTS.TicTacToe.Engine;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GUTS.TicTacToe.Unity
{
    public class TicTacToeUI : MonoBehaviour
    {
        [SerializeField] private Button m_startNewGameButton;
        [SerializeField] private TMP_Text m_statusText;
        [SerializeField] private GameObject m_boardGrid;

        private TicTacToeGame _ticTacToeGame;

        private GridButton[] _boardButtons;

        private void Awake()
        {
            _ticTacToeGame = GetComponent<TicTacToeGame>();

            _boardButtons = m_boardGrid.GetComponentsInChildren<GridButton>();

            m_startNewGameButton.onClick.AddListener(OnClick_StartNewGame);

            for (int i = 0; i < _boardButtons.Length; i++)
            {
                int index = i; // Capture index for the lambda
                _boardButtons[i].GetComponent<Button>().onClick.AddListener(() =>
                {
                    OnClick_BoardButton(index);
                });
            }
        }

        private void Start()
        {
            OnClick_StartNewGame();
        }

        public void OnClick_StartNewGame()
        {
            _ticTacToeGame.StartNewGame();
            TicTacToeEvents.OnNewGame?.Invoke();

            UpdateGameView();
        }

        private void OnClick_BoardButton(int index)
        {
            Player player = _ticTacToeGame.CurrentPlayer;
            Position pos = BoardState.IndexToPosition(index);

            bool moved = _ticTacToeGame.MakeMove(index);

            GameResult result = _ticTacToeGame.GetGameResult();

            if (result != GameResult.Ongoing)
                TicTacToeEvents.OnGameEnding?.Invoke();

            if (moved)
                TicTacToeEvents.OnMoveMade?.Invoke(pos, player);
            else
                TicTacToeEvents.OnMoveRejected?.Invoke(pos, player);

            UpdateGameView();
        }

        private void UpdateGameView()
        {
            GameResult result = _ticTacToeGame.GetGameResult();

            if (result != GameResult.Ongoing)
                TicTacToeEvents.OnGameOver?.Invoke(result);

            UpdatePlayButtons(result);
            UpdateStatusText(result);
            UpdateBoardButtons(result);
        }

        private void UpdatePlayButtons(GameResult result)
        {
            m_startNewGameButton.interactable = (result != GameResult.Ongoing);
        }

        private void UpdateStatusText(GameResult result)
        {
            m_statusText.text = result switch
            {
                GameResult.Ongoing => $"Current Turn: {_ticTacToeGame.CurrentPlayer}",
                GameResult.Draw => "Game ended in a Draw!",
                GameResult.XWins => "Player X Wins!",
                GameResult.OWins => "Player O Wins!",
                _ => "Unknown Game State"
            };
        }

        private void UpdateBoardButtons(GameResult result)
        {
            Player[] playerGrid = _ticTacToeGame.GetPlayerGrid();
            Position[] winPositions = _ticTacToeGame.GetWinningPositions();

            bool? forceInteractable = (result == GameResult.Ongoing) ? null : false;

            for (int i = 0; i < _boardButtons.Length; i++)
            {
                _boardButtons[i].SetPlayer(playerGrid[i], forceInteractable);

                bool isWinning = (winPositions != null) &&
                    winPositions.Contains(BoardState.IndexToPosition(i));

                _boardButtons[i].SetHighlight(isWinning);
            }
        }
    }
}
