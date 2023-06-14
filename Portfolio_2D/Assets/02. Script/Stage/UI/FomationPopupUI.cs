using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Portfolio.UI;

namespace Portfolio.WorldMap
{
    public class FomationPopupUI : MonoBehaviour
    {
        [SerializeField] ScrollRect unitScrollView;

        List<UnitSlotUI> unitSlotList = new List<UnitSlotUI>();

        private void Awake()
        {
            foreach (var unitSlotUI in unitScrollView.content.GetComponentsInChildren<UnitSlotUI>())
            {
                unitSlotList.Add(unitSlotUI);
            }
        }

        private void Start()
        {
            this.gameObject.SetActive(false);
        }

        public void ShowPopup()
        {
            ShowUnitList();
            this.gameObject.SetActive(true);
        }

        public void ShowUnitList()
        {
            var userUnitList = GameManager.CurrentUser.userUnitList;
            for (int i = 0; i < unitSlotList.Count; i++)
            {
                if (userUnitList.Count <= i)
                {
                    unitSlotList[i].gameObject.SetActive(false);
                    continue;
                }

                unitSlotList[i].Init(userUnitList[i]);
                unitSlotList[i].gameObject.SetActive(true);
            }

        }
    }
}