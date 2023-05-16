using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Portfolio
{
    public class ActionSystem : MonoBehaviour
    {
        public static ActionSystem Instance { get; private set; }

        private bool isActionTime = false;

        private List<Unit> SelectedUnits;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(this.gameObject);
            }

            SelectedUnits = new List<Unit>();

            BattleManager.Instance.PublishEvent(BattleState.PLAYERTURN, () => {
                isActionTime = true; 
            });
            BattleManager.Instance.PublishEvent(BattleState.WATTINGTURN, () => { 
                isActionTime = false;
                ClearSelectedUnits();
            });
            BattleManager.Instance.PublishEvent(BattleState.ENEMYTURN, () => { 
                isActionTime = false;
                ClearSelectedUnits();
            });
        }

        void Update()
        {
            if (!isActionTime) return;

            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit2D hit2D = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

                if (hit2D.collider?.transform.gameObject.layer == 6)
                {
                    SelectedUnit(hit2D.transform.GetComponent<Unit>());
                }
            }
        }

        private void SelectedUnit(Unit unit)
        {
            unit.SetSelectedSprte(true);
            SelectedUnits.Add(unit);
        }

        private void ClearSelectedUnits()
        {
            Debug.Log("Clear");
            foreach (var unit in SelectedUnits)
            {
                unit.SetSelectedSprte(false);
            }

            SelectedUnits.Clear();
        }
    }
}