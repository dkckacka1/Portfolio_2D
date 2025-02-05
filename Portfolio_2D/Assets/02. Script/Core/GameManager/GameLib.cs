﻿using System;
using System.Security.Cryptography;
using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.Events;

/*
 * 게임 함수 모음 static 클래스
 */

namespace Portfolio
{
    public static class GameLib
    {
        // 옵션 스탯 정보에 맞게 텍스트를 출력
        public static string GetOptionStatusText(eEquipmentOptionStat optionStat)
        {
            switch (optionStat)
            {
                case eEquipmentOptionStat.AttackPoint:
                    return "공격력";
                case eEquipmentOptionStat.AttackPercent:
                    return "공격력(%)";
                case eEquipmentOptionStat.HealthPoint:
                    return "생명력";
                case eEquipmentOptionStat.HealthPercent:
                    return "생명력(%)";
                case eEquipmentOptionStat.DefencePoint:
                    return "방어력";
                case eEquipmentOptionStat.DefencePercent:
                    return "방어력(%)";
                case eEquipmentOptionStat.CriticalPercent:
                    return "치명타 적중";
                case eEquipmentOptionStat.CriticalDamagePercent:
                    return "치명타 피해";
                case eEquipmentOptionStat.Speed:
                    return "속도";
                case eEquipmentOptionStat.EffectHitPercent:
                    return "효과 적중";
                case eEquipmentOptionStat.EffectResistancePercent:
                    return "효과 저항";
                default:
                    Debug.LogWarning("unknownType");
                    break;
            }

            return "없음";
        }

        // 장비 아이템 타입 텍스트를 출력
        public static string GetEquipmentTypeText(eEquipmentItemType type)
        {
            switch (type)
            {
                case eEquipmentItemType.Weapon:
                    return "무기";
                case eEquipmentItemType.Helmet:
                    return "투구";
                case eEquipmentItemType.Armor:
                    return "갑옷";
                case eEquipmentItemType.Amulet:
                    return "목걸이";
                case eEquipmentItemType.Ring:
                    return "반지";
                case eEquipmentItemType.Shoe:
                    return "신발";
                default:
                    Debug.LogWarning("unknownType");
                    break;
            }

            return "없음";
        }

        // 장비 등급 텍스트 출력
        public static string GetGradeTypeText(eGradeType type)
        {
            switch (type)
            {
                case eGradeType.Normal:
                    return "일반";
                case eGradeType.Rare:
                    return "희귀";
                case eGradeType.Unique:
                    return "고유";
                case eGradeType.Legendary:
                    return "전설";
                default:
                    Debug.LogWarning("unknownType");
                    break;
            }

            return "없음";
        }

        // 장비 속성 텍스트 출력
        public static string GetSetTypeText(eSetType type)
        {
            return "";

            switch (type)
            {
                case eSetType.Critical:
                    return "치명";
                case eSetType.Hit:
                    return "적중";
                case eSetType.Speed:
                    return "속도";
                case eSetType.Attack:
                    return "공격";
                case eSetType.Defence:
                    return "방어";
                case eSetType.Health:
                    return "체력";
                case eSetType.Resistance:
                    return "저항";
                case eSetType.Destruction:
                    return "파멸";
                default:
                    Debug.LogWarning("unknownType");
                    break;
            }

            return "없음";
        }

        /// <summary>
        /// 확률 계산 true면 성공, false면 실패
        /// </summary>
        /// <param name="value">확률</param>
        /// <param name="seed">들어온 값</param>
        /// <returns></returns>
        public static bool ProbabilityCalculation(float value, float maxValue = 100f)
        {
            float probability = UnityEngine.Random.Range(0, maxValue);
            //Debug.Log($"{value} > {probability} = {value > probability}");
            return value > probability;
        }

        public static float UnitBattlePowerSort(Unit arg)
        {
            return arg.battlePower;
        }

        // 문자열을 해시 변환 해주는 함수
        public static string ComputeSHA256(string s)
        {
            string hash = String.Empty;

            // SHA256 해시 객체 초기화
            using (SHA256 sha256 = SHA256.Create())
            {
                // 주어진 문자열의 해시를 계산합니다.
                byte[] hashValue = sha256.ComputeHash(Encoding.UTF8.GetBytes(s));

                // 바이트 배열을 문자열 형식으로 변환
                foreach (byte b in hashValue)
                {
                    hash += $"{b:X2}";
                }
            }
            return hash;
        }

        // 일정 시간 후 함수를 호출하고 싶을때 사용 (UnityAction형만)
        public static IEnumerator WaitMethodCall(float waitTime, UnityAction action)
        {
            yield return new WaitForSeconds(waitTime);

            action?.Invoke();
        }
    }
}