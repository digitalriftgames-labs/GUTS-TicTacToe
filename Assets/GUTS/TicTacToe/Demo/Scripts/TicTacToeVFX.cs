using GUTS.TicTacToe.Engine;
using System.Collections;
using UnityEngine;

namespace GUTS.TicTacToe.Unity
{
    public class TicTacToeVFX : MonoBehaviour
    {
        [SerializeField] private Camera m_camera;
        [SerializeField] private float m_fadeDuration = 0.25f;

        [Header("Colors")]
        [SerializeField] private Color m_ongoingColor = new Color32(0x31, 0x4D, 0x79, 255);
        [SerializeField] private Color m_xWinColor = new Color32(0xC0, 0x39, 0x2B, 255);
        [SerializeField] private Color m_oWinColor = new Color32(0x27, 0xAE, 0x60, 255);
        [SerializeField] private Color m_drawColor = new Color32(0x7F, 0x8C, 0x8D, 255);

        private void OnEnable()
        {
            TicTacToeEvents.OnNewGame += SetOngoingColor;
            TicTacToeEvents.OnGameOver += SetGameOverColor;
        }

        private void OnDisable()
        {
            TicTacToeEvents.OnNewGame -= SetOngoingColor;
            TicTacToeEvents.OnGameOver -= SetGameOverColor;
        }

        private void SetOngoingColor()
        {
            StartCoroutine(FadeTo(m_ongoingColor));
        }

        private void SetGameOverColor(GameResult result)
        {
            Color target = result switch
            {
                GameResult.XWins => m_xWinColor,
                GameResult.OWins => m_oWinColor,
                GameResult.Draw => m_drawColor,
                _ => m_ongoingColor
            };

            StartCoroutine(FadeTo(target));
        }

        private IEnumerator FadeTo(Color target)
        {
            Color start = m_camera.backgroundColor;
            float t = 0f;

            while (t < m_fadeDuration)
            {
                m_camera.backgroundColor = Color.Lerp(start, target, t / m_fadeDuration);
                t += Time.deltaTime;
                yield return null;
            }

            m_camera.backgroundColor = target;
        }

        private void Reset()
        {
            m_camera = Camera.main;
        }
    }
}
