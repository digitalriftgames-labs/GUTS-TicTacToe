using GUTS.TicTacToe.Engine;
using System.Collections;
using UnityEngine;

namespace GUTS.TicTacToe.Unity
{
    public class TicTacToeUIFX : MonoBehaviour
    {
        [SerializeField] private float m_movePopDuration = 0.2f;
        [SerializeField] private float m_movePopScale = 1.2f;
        [Space]
        [SerializeField] private RectTransform m_boardButtons;

        private void OnEnable()
        {
            TicTacToeEvents.OnMoveMade += PlayMoveFX;
        }

        private void OnDisable()
        {
            TicTacToeEvents.OnMoveMade -= PlayMoveFX;
        }

        private void PlayMoveFX(Position pos, Player player)
        {
            int index = BoardState.PositionToIndex(pos);
            Transform button = m_boardButtons.GetChild(index);
            StartCoroutine(Pop(button));
        }

        private IEnumerator Pop(Transform t)
        {
            Vector3 original = t.localScale;
            Vector3 enlarged = original * m_movePopScale;

            float duration = m_movePopDuration / 2.0f;

            float time = 0f;
            while (time < duration)
            {
                t.localScale = Vector3.Lerp(original, enlarged, time / duration);
                time += Time.deltaTime;
                yield return null;
            }

            time = 0f;
            while (time < duration)
            {
                t.localScale = Vector3.Lerp(enlarged, original, time / duration);
                time += Time.deltaTime;
                yield return null;
            }

            t.localScale = original;
        }
    }
}
