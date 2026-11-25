using System.Collections;
using UnityEngine;
using YG;

namespace Assets.Scripts.ADV
{
    public class ADVShow : MonoBehaviour
    {
        private void Start()
        {
            StartCoroutine(ADVCoroutine());
        }
        private IEnumerator ADVCoroutine()
        {
            while(true)
            {
                if (true) // ЕСЛИ УРОВЕНЬ НИЖЕ УРОВНЯ ПЯТОЙ МИНУТЫ
                {
                    while (true) yield return new WaitForSeconds(2f); // В УСЛОВИЯХ ВСТАВИТЬ ПРИМЕРНЫЙ УРОВЕНЬ НА ПЯТОЙ МИНУТЕ
                    YG2.InterstitialAdvShow();
                }

                yield return new WaitForSeconds(1f);
                Debug.Log("coroutine");
            }
        }
    }
}