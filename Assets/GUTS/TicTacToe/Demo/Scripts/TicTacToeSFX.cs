using GUTS.TicTacToe.Engine;
using UnityEngine;

namespace GUTS.TicTacToe.Unity
{
    public class TicTacToeSFX : MonoBehaviour
    {
        [SerializeField] private AudioClip m_newGameSound;
        [SerializeField] private AudioClip m_moveMadeSound;
        [SerializeField] private AudioClip m_moveRejectedSound;
        [SerializeField] private AudioClip m_winSound;
        [SerializeField] private AudioClip m_drawSound;
        [Space]
        [SerializeField] private AudioSource m_audioSource;

        private bool _gameEnding;

        private void Awake()
        {
            if (m_audioSource == null)
                Debug.LogWarning("[TicTacToeAudio] No AudioSource assigned. Audio will not play.");
        }

        private void OnEnable()
        {
            TicTacToeEvents.OnNewGame += PlayNewGame;
            TicTacToeEvents.OnMoveMade += PlayMoveMade;
            TicTacToeEvents.OnMoveRejected += PlayMoveRejected;
            TicTacToeEvents.OnGameEnding += SetGameEndingFlag;
            TicTacToeEvents.OnGameOver += PlayGameOver;
        }

        private void OnDisable()
        {
            TicTacToeEvents.OnNewGame -= PlayNewGame;
            TicTacToeEvents.OnMoveMade -= PlayMoveMade;
            TicTacToeEvents.OnMoveRejected -= PlayMoveRejected;
            TicTacToeEvents.OnGameEnding -= SetGameEndingFlag;
            TicTacToeEvents.OnGameOver -= PlayGameOver;
        }

        private void SetGameEndingFlag()
        {
            _gameEnding = true;
        }

        private void PlayNewGame() => Play("New Game", m_newGameSound);

        private void PlayMoveMade(Position pos, Player player)
        {
            if (_gameEnding) return;

            Play("Move Made", m_moveMadeSound);
        }

        private void PlayMoveRejected(Position pos, Player player) => Play("Move Rejected", m_moveRejectedSound);

        private void PlayGameOver(GameResult result)
        {
            string clipName = (result == GameResult.Draw) ? "Draw" : "Win";
            AudioClip clip = (result == GameResult.Draw) ? m_drawSound : m_winSound;
            Play(clipName, clip);

            _gameEnding = false; // OnGameEnding handled, reset flag
        }

        private void Play(string clipName, AudioClip clip)
        {
            if (clip == null)
            {
                Debug.Log($"[TicTacToeAudio] Would play sound: {clipName} (no clip assigned)");
                return;
            }

            Debug.Log($"[TicTacToeAudio] Playing sound: {clipName}");
            m_audioSource.PlayOneShot(clip);
        }

        private void Reset()
        {
            m_audioSource = GetComponentInChildren<AudioSource>();
        }
    }
}
