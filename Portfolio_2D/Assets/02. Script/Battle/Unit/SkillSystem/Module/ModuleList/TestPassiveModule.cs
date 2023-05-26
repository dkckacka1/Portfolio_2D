using Portfolio.skill;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Portfolio.Condition;

namespace Portfolio.skill.module
{
    public class TestPassiveModule : Module
    {
        public override void Action(SkillActionEventArgs args)
        {
            args.targetUnit.AddCondition("AttackIncrease", new IncreaseAttackDamage(), 3);
        }

        public override string ShowDesc(int skillLevel)
        {
            return "";
        }
    }

}