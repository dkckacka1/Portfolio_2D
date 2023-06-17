using Portfolio.skill;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Portfolio.Lobby.Hero
{
    public class HeroPanelUI : PanelUI
    {
        [SerializeField] UnitListUI unitListUI;
        [SerializeField] UnitStatusUI unitStatusUI;
        [SerializeField] UnitEquipmentUI unitEquipmentUI;
        [SerializeField] UnitSkillPanelUI unitSkillPanelUI;
        [SerializeField] EquipmentPopupUI equipmentPopupUI;
        [SerializeField] EquipmentReinforcePopupUI reinforcePopupUI;
        [SerializeField] EquipmentListPopupUI equipmentListPopupUI;
        [SerializeField] EquipmentTooltip equipmentTooltipUI;
        [SerializeField] SkillLevelUpPopupUI skillLevelUpPopupUI;

        private static Unit selectUnit;
        public static Unit SelectUnit
        {
            get
            {
                return selectUnit;
            }
            set
            {
                selectUnit = value;
                LobbyManager.UIManager.OnUnitChanged();
            }
        }
        private static EquipmentItemData selectEquipmentItem;
        public static EquipmentItemData SelectEquipmentItem
        {
            get
            {
                return selectEquipmentItem;
            }
            set
            {
                selectEquipmentItem = value;
                LobbyManager.UIManager.OnEquipmentItemChanged();
            }
        }
        private static EquipmentItemType selectEquipmentItemType = EquipmentItemType.Weapon;
        public static EquipmentItemType SelectEquipmentItemType
        {
            get
            {
                return selectEquipmentItemType;
            }
            set
            {
                selectEquipmentItemType = value;
            }
        }
        private static EquipmentItemData choiceEquipmentItem;
        public static EquipmentItemData ChoiceEquipmentItem
        {
            get
            {
                return choiceEquipmentItem;
            }
            set
            {
                choiceEquipmentItem = value;
                LobbyManager.UIManager.OnEquipmentItemChanged();
            }
        }
        private static Skill selectSkill;
        public static Skill SelectSkill
        {
            get
            {
                return selectSkill;
            }
            set
            {
                selectSkill = value;
            }
        }
        private static UnitSkillType selectSkillType;
        public static UnitSkillType SelectSkillType
        {
            get
            {
                return selectSkillType;
            }
            set
            {
                selectSkillType = value;
            }
        }
        private void Awake()
        {
            unitListUI.Init();
            unitStatusUI.Init();
            unitEquipmentUI.Init();
            unitSkillPanelUI.Init();
            equipmentPopupUI.Init();
            reinforcePopupUI.Init();
            equipmentListPopupUI.Init();
        }

        private void Start()
        {
            SelectUnit = GameManager.CurrentUser.userUnitList[0];
        }

        protected override void OnEnable()
        {
            base.OnEnable();
        }

        private void OnDisable()
        {
            // 초기 상태로 되돌리기
            equipmentPopupUI.gameObject.SetActive(false);
            reinforcePopupUI.gameObject.SetActive(false);
            equipmentListPopupUI.gameObject.SetActive(false);
            equipmentTooltipUI.gameObject.SetActive(false);
        }

        public void ReShow()
        {
            unitListUI.ShowUnitList();
            LobbyManager.UIManager.OnUnitChanged();
            LobbyManager.UIManager.OnEquipmentItemChanged();
        }

        //===========================================================
        // ShowUI
        //===========================================================
        public void ShowEquipmentUI()
        {
            if (!unitEquipmentUI.gameObject.activeInHierarchy)
            {
                if (LobbyManager.UIManager.UndoCount() >= 2)
                {
                    LobbyManager.UIManager.Undo();
                }

                unitEquipmentUI.gameObject.SetActive(true);
                LobbyManager.UIManager.AddUndo(unitEquipmentUI);
            }
        }

        public void ShowSkillUI()
        {
            if (!unitSkillPanelUI.gameObject.activeInHierarchy)
            {
                if (LobbyManager.UIManager.UndoCount() >= 2)
                {
                    LobbyManager.UIManager.Undo();
                }

                unitSkillPanelUI.gameObject.SetActive(true);
                LobbyManager.UIManager.AddUndo(unitSkillPanelUI);
            }
        }

        public void ShowEquipmentPopupUI()
        {
            equipmentPopupUI.gameObject.SetActive(true);
            reinforcePopupUI.gameObject.SetActive(false);
            equipmentListPopupUI.gameObject.SetActive(false);
        }

        public void ShowReinforcePopup()
        {
            reinforcePopupUI.gameObject.SetActive(true);
            equipmentListPopupUI.gameObject.SetActive(false);
        }

        public void ShowEquipmentListPopup()
        {
            equipmentListPopupUI.gameObject.SetActive(true);
            reinforcePopupUI.gameObject.SetActive(false);
        }

        //===========================================================
        // BtnPlugin
        //===========================================================
        public void Reinforce()
        {
            GameManager.CurrentUser.userData.gold -= Constant.reinforceConsumeGoldValues[selectEquipmentItem.reinforceCount];

            if (Random.Range(0f, 1f) <= Constant.reinforceProbabilitys[selectEquipmentItem.reinforceCount])
            {
                GameManager.ItemCreator.ReinforceEquipment(selectEquipmentItem);
                ReShow();
            }

            LobbyManager.UIManager.ShowUserResource();
            GameManager.Instance.SaveUser();
        }

        public void ReleaseEquipment()
        {
            var releaseItem = selectUnit.ReleaseEquipment(selectEquipmentItemType);
            GameManager.CurrentUser.userEquipmentItemDataList.Add(releaseItem);
            selectEquipmentItem = null;
            choiceEquipmentItem = null;

            equipmentListPopupUI.UnChoiceList();
            ReShow();
            GameManager.Instance.SaveUser();
        }

        public void ChangeEquipment()
        {
            GameManager.CurrentUser.userEquipmentItemDataList.Remove(choiceEquipmentItem);
            var releaseItem = selectUnit.ChangeEquipment(selectEquipmentItemType, choiceEquipmentItem);
            if (releaseItem != null)
            {
                GameManager.CurrentUser.userEquipmentItemDataList.Add(selectEquipmentItem);
            }

            selectEquipmentItem = choiceEquipmentItem;
            choiceEquipmentItem = null;
            equipmentListPopupUI.UnChoiceList();
            ReShow();
            GameManager.Instance.SaveUser();
        }

        public void GetExperience(float getValue)
        {
            selectUnit.CurrentExperience += getValue;
            ReShow();
        }

        public void SkillLevelUp(UnitSkillType type, int levelUPCount)
        {
            selectUnit.SkillLevelUp(type, levelUPCount);
        }
    }
}
