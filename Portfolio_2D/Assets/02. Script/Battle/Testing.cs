using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Portfolio
{
    public class Testing : MonoBehaviour
    {
        int num = 0;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                GameManager.Instance.TryGetUnit(100, out Unit unit);
                var unitBase = BattleManager.BattleFactory.CreatePlayableUnitBase(unit);
                unitBase.BattleUnit.name = unit.Data.unitName + "_" + num++;
                unitBase.BattleUnit.Speed = Random.Range(50, 101);
                BattleManager.Instance.AddUnitinUnitList(unitBase.BattleUnit);
            }

            if (Input.GetKeyDown(KeyCode.Y))
            {
                var unitBase = BattleManager.BattleFactory.CreateEnemyUnitBase();
                unitBase.BattleUnit.name = "Enemy_" + num++;
                unitBase.BattleUnit.Speed = Random.Range(50, 101);
                BattleManager.Instance.AddUnitinUnitList(unitBase.BattleUnit);
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                foreach (var unit in BattleManager.ActionSystem.SelectedUnits)
                {
                    unit.TakeDamage(10);
                }
            }
        }
    }

}