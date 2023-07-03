using Portfolio.Battle;
using Portfolio.condition;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Portfolio.skill
{
    public class Skill_ZICH_ActiveSkill_1 : ActiveSkill
    {
        public Skill_ZICH_ActiveSkill_1(ActiveSkillData skillData) : base(skillData)
        {

        }

        public override IEnumerable<BattleUnit> SetTarget(BattleUnit actionUnit, List<BattleUnit> targetUnits)
        {
            return targetUnits.GetAllyTarget(actionUnit).GetTargetNum(this);
        }

        protected override IEnumerator PlaySkill(SkillActionEventArgs e)
        {
            foreach (var targetUnit in e.targetUnits)
            {
                targetUnit.AddCondition(conditionList[0].conditionID, conditionList[0], 1 + e.skillLevel);
                var effect = BattleManager.ObjectPool.SpawnSkillEffect();
                effect.PlayEffect("Anim_Skill_Effect_ZICH_ActiveSkill1");
                effect.transform.position = targetUnit.footPos.position;
            }
            yield return new WaitForSeconds(0.5f);

            e.actionUnit.isSkillUsing = false;
        }
    }
}