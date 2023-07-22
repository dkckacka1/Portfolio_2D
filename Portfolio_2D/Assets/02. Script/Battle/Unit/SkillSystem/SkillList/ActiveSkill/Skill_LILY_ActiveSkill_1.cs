using Portfolio.Battle;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 릴리 유닛의 액티브 스킬 1 클래스
 */

namespace Portfolio.skill
{
    public class Skill_LILY_ActiveSkill_1 : ActiveSkill
    {
        public Skill_LILY_ActiveSkill_1(ActiveSkillData skillData) : base(skillData)
        {
        }

        public override IEnumerable<BattleUnit> SetTarget(BattleUnit actionUnit, List<GridPosition> targetUnits)
        {
            // 아군에서 체력이 낮은 순으로 1명 타겟
            return targetUnits.GetAllyTarget(actionUnit).OrderLowHealth().GetTargetNum(this).SelectBattleUnit();
        }

        protected override IEnumerator PlaySkill(SkillActionEventArgs e)
        {
            foreach (var targetUnit in e.targetUnits)
            {
                // 체력 회복 수치는 대상 체력의 상대 수치
                float healValue = targetUnit.MaxHP * (0.3f + (e.skillLevel * GetData.skillLevelValue_1 * 0.01f));
                // 대상의 체력을 회복
                e.actionUnit.HealTarget(targetUnit, healValue);
            }
            GameManager.AudioManager.PlaySoundOneShot("Sound_Skill_LILY_ActiveSkill_Heal");
            yield return new WaitForSeconds(0.5f);

            // 스킬 종료
            e.actionUnit.isSkillUsing = false;
        }
    }
}