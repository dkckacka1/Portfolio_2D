using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 시간과 관련 시스템 클래스
 */

namespace Portfolio
{
    public class TimeChecker : MonoBehaviour
    {
        public int energyChargeCount = (int)Constant.EnergyChargeTime; // 에너지 회복 시간

        private IEnumerator checkIEnumerator;   // 에너지 체크 열거자

        public void CheckEnergy()
        {
            // 에너지 회복 체크를 시작한다.
            checkIEnumerator = EnergyCheckCoroutine();

            StartCoroutine(checkIEnumerator);
        }

        // 에너지 회복을 중단합니다.
        public void StopCheckEnergy()
        {
            StopCoroutine(checkIEnumerator);

            checkIEnumerator = null;
        }

        // 에너지 회복 코루틴
        private IEnumerator EnergyCheckCoroutine()
        {
            while (true)
            {
                // 1초당 한번씩 체크다.
                yield return new WaitForSecondsRealtime(1f);
                // 회복 시간 1씩 감소
                energyChargeCount--;
                // 회복 시간이 0 이하가 되면
                if (energyChargeCount <= 0)
                {
                    // 유저의 에너지를 회복한다.
                    GameManager.CurrentUser.CurrentEnergy++;
                    // 회복 시간을 초기화 한다.
                    energyChargeCount = (int)Constant.EnergyChargeTime;
                }
                // UI를 업데이트 한다.
                GameManager.UIManager.ShowRemainTime(energyChargeCount);
            }
        }
    }
}