using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Portfolio.Battle
{
    public class TurnBaseSystem : MonoBehaviour
    {
        [SerializeField] private float turnCount = 100f;
        [SerializeField] private UnitTurnBase currentTurnUnit = null;
        [SerializeField] TextMeshProUGUI currentTurnUnitNameText;

        private List<UnitTurnBase> unitTurnBaseList = new List<UnitTurnBase>();
        private TurnType currentTurnType;

        public List<UnitTurnBase> UnitTurnBaseList { get => unitTurnBaseList; }
        public TurnType CurrentTurnType { get => currentTurnType; }
        public UnitTurnBase CurrentTurnUnit { get => currentTurnUnit; }

        private void Update()
        {
            if (BattleManager.Instance.BattleState == BattleState.PLAY && currentTurnType == TurnType.WAITUNITTURN)
            {
                foreach (UnitTurnBase unitTurnBase in unitTurnBaseList)
                {
                    if (unitTurnBase.currentTurnCount >= turnCount)
                    {
                        StartTurn(unitTurnBase);

                        break;
                    }

                    ProceedTurn(unitTurnBase);
                }
            }
        }

        public void AddUnitTurnBase(UnitTurnBase unitTurnBase)
        {
            unitTurnBaseList.Add(unitTurnBase);
            ProceedTurn(unitTurnBase);
        }

        public bool IsUnitTurn(UnitTurnBase unitTurn)
        {
            return currentTurnUnit == unitTurn;
        }

        private void ProceedTurn(UnitTurnBase unitTurnBase)
        {
            unitTurnBase.AddUnitTurnCount(unitTurnBase.BattleUnit.Speed * Time.deltaTime);
            float SequenceUIYNormalizedPos = unitTurnBase.GetCurrentTurnCount() / turnCount;

            BattleManager.BattleUIManager.SequenceUI.SetSequenceUnitUIYPosition(unitTurnBase.UnitSequenceUI, SequenceUIYNormalizedPos);
        }

        public void StartTurn(UnitTurnBase unitbase)
        {
            currentTurnUnit = unitbase;
            if (!unitbase.BattleUnit.IsEnemy)
            {
                BattleManager.ActionSystem.IsPlayerActionTime = true;
                currentTurnType = TurnType.PLAYER;
            }
            else
            {
                currentTurnType = TurnType.ENEMY;
            }

            currentTurnUnitNameText.text = unitbase.BattleUnit.Unit.UnitName;
            currentTurnUnitNameText.gameObject.SetActive(true);
            currentTurnUnit.TurnStart();
        }

        public void TurnEnd()
        {
            if (currentTurnUnit == null) return;

            currentTurnUnit.TurnEnd();
            BattleManager.BattleUIManager.SequenceUI.SetSequenceUnitUIYPosition(currentTurnUnit.UnitSequenceUI, 0);
            BattleManager.ActionSystem.ClearSelectedUnits();
            currentTurnUnit = null;
            currentTurnType = TurnType.WAITUNITTURN;
            BattleManager.ActionSystem.IsPlayerActionTime = false;
            currentTurnUnitNameText.gameObject.SetActive(false);
        }

        public void ResetAllUnitTurn()
        {
            foreach(var unitTurnBase in unitTurnBaseList)
            {
                unitTurnBase.ResetUnitTurnCount();
                ProceedTurn(unitTurnBase);
            }
        }
    }

}