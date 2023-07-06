﻿using UnityEngine;

/*
 * 게임에서 사용되는 상수들만 모아놓은 static 클래스
 */

namespace Portfolio
{
    public static class Constant
    {
        //===========================================================
        // GameValue
        //===========================================================
        // 최대 강화 횟수
        public const float MAX_REINFORCE_COUNT = 15;
        // 강화 레벨에 따른 강화 비용
        public static readonly int[] reinforceConsumeGoldValues = { 100, 500, 1000, 2000, 4000, 10000, 15000, 30000,75000,100000,150000,300000,750000,1500000,2000000 };
        // 평범 등급 아이템의 색
        public static readonly Color normalColor = new Color(1, 1, 1, 1);
        // 희귀 등급 아이템의 색
        public static readonly Color rareColor = new Color(0.3f, 0.3f, 1, 1);
        // 고유 등급 아이템의 색
        public static readonly Color uniqueColor = new Color(1, 1, 0, 1);
        // 전설 등급 아이템의 색
        public static readonly Color legendaryColor = new Color(1, 0.5f, 0, 1);
        // 아군의 색
        public static readonly Color playerColor = new Color(0, 1, 0, 1);
        // 적군의 색
        public static readonly Color enemyColor = new Color(1, 0, 0, 1);
        // 유닛 레벨당 올라갈 최대 경험치 량
        public const float unitLevelUpExperienceVluae = 1000f;
        // 에너지 회복 시간
        public const float energyChargeTime = 10f;
        // 유저 유닛 리스트 최대 갯수를 올릴 때 소비할 다이아 량
        public const int unitListSizeUPDiaConsumeValue = 50;
        // 유저 유닛 리스트 최대 갯수를 올릴 때 올라갈 갯수
        public const int unitListSizeUpCount = 5;
        // 유저 유닛 리스트 최대 갯수의 맥시멈
        public const int unitListMaxSizeCount = 100;
        // 한번 소환할 때 소비되는 다이아 량
        public const int summon_1_unitConsumeDiaValue = 30;
        // 열번 소환할 때 소비되는 다이아 량
        public const int summon_10_unitConsumeDiaValue = 270;

        //===========================================================
        // RandomValue
        //===========================================================
        // 유닛 소환 시 1성 등급 유닛이 나올 확률
        public const float normalSummonPercent = 0.70f;
        // 유닛 소환 시 2성 등급 유닛이 나올 확률
        public const float rareSummonPercent = 0.25f;
        // 유닛 소환 시 3성 등급 유닛이 나올 확률
        public const float uniqueSummonPercent = 0.05f;
        // 장비 강화시 강화 레벨에 따른 강화 확률
        public static readonly float[] reinforceProbabilitys = { 1f, 0.95f, 0.9f, 0.85f, 0.8f, 0.78f, 0.75f, 0.73f, 0.71f, 0.7f, 0.69f, 0.67f, 0.65f, 0.63f, 0.6f};

        //===========================================================
        // BattleValue
        //===========================================================
        // 전투 시 최대 마나량
        public const int MAX_MANA_COUNT = 4;

        //===========================================================
        // AIValue
        //===========================================================

        //===========================================================
        // Path
        //===========================================================
        // 엑셀 데이터 테이블 참조 위치
        public const string dataTablePath = @"\05. DataTable\";
        // 엑셀을 json으로 만들 때 Json 저장 위치
        public const string resorucesDataPath = @"\Resources\Data\";
        // 스킬 데이터 테이블 이름
        public const string skillDataTableName = @"SkillDataTable";
        // 액티브 스킬 Json 파일 이름
        public const string activeSkillJsonName = @"ActiveSkillData";
        // 패시브 스킬 Json 파일 이름
        public const string passiveSkillJsonName = @"PassiveSkillData";
        // 유닛 데이터 테이블 이름
        public const string unitDataTableName = @"UnitDataTable";
        // 유닛 Json 파일 이름
        public const string unitDataJsonName = @"UnitData";
        // 상태이상 데이터 테이블 이름
        public const string conditionDataTableName = @"ConditionDataTable";
        // 상태이상 Json 파일 이름
        public const string conditionDataJsonName = @"ConditionData";
        // 맵 데이터 테이블 이름
        public const string mapDataTableName = @"MapDataTable";
        // 맵 Json 파일 이름
        public const string mapDataJsonName = @"MapData";
        // 스테이지 Json 파일 이름
        public const string stageDataJsonName = @"StageData";
        // 아이템 데이터 테이블 이름
        public const string itemDataTableName = @"ItemDataTable";
        // 소비아이템 Json 파일 이름
        public const string consumableItemDataJsonName = @"ConsumableItemData";


    }
}
