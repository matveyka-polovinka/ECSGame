using System;
using System.Collections;
using UnityEngine;
using YG;

namespace Assets.Scripts.ADV
{
    public class ADVShow : MonoBehaviour
    {
        private const int LowerLimit = 80;
        private const int HighLimit = 130;

        public static Action ShowAdvFree;

        private IntervalState _state = IntervalState.NotReady;
        private int _timer = 0;

        private void Start()
        {
            ShowAdvFree += ShowAdvFreeFunc;

            StartCoroutine(ADVCoroutine());
        }

        private void ShowAdvFreeFunc()
        {
            if (_state == IntervalState.Ready)
            {
                YG2.InterstitialAdvShow();
                _timer = 0;
                _state = IntervalState.NotReady;
            }
        }
        private IEnumerator ADVCoroutine()
        {
            if (!YG2.saves.isFirstStageAdvCompleted)
            {
                while (true)
                {
                    if (true) // ЕСЛИ УРОВЕНЬ НИЖЕ УРОВНЯ ПЯТОЙ МИНУТЫ
                    {
                        while (true) yield return new WaitForSeconds(2f); // В УСЛОВИЯХ ВСТАВИТЬ ПРИМЕРНЫЙ УРОВЕНЬ НА ПЯТОЙ МИНУТЕ
                        YG2.InterstitialAdvShow();
                    }
                    yield return new WaitForSeconds(1f);
                }
                YG2.saves.isFirstStageAdvCompleted = true;
            }
            else
            {
                while (true)
                {
                    yield return new WaitForSeconds(1f);

                    _timer++;

                    if (_timer < LowerLimit) continue;

                    if (_timer > HighLimit)
                    {
                        // Принудительная реклама с подарком
                    }
                    if (_timer < HighLimit && _timer > LowerLimit)
                    {
                        _state = IntervalState.Ready;
                    }
                }
            }
        }
    }
    public enum IntervalState
    {
        Ready,
        NotReady,
        GiftReady,
    }
}