using Portfolio.Battle;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Portfolio
{
    public class Testing : MonoBehaviour
    {
        private void Update()
        {
            //if (Input.GetKeyDown(KeyCode.T))
            //{
            //    GameManager.Instance.TryGetUnit(100, out Unit unit);

            //    if (BattleManager.BattleFactory.TryCreateBattleUnit(unit, false, out BattleUnit battleUnit))
            //    {
            //        battleUnit.Speed = Random.Range(50, 101);
            //        BattleManager.Instance.AddUnitinUnitList(battleUnit);
            //    }
            //}

            //if (Input.GetKeyDown(KeyCode.Y))
            //{
            //    GameManager.Instance.TryGetUnit(100, out Unit unit);

            //    if (BattleManager.BattleFactory.TryCreateBattleUnit(unit, true, out BattleUnit battleUnit))
            //    {
            //        battleUnit.Speed = Random.Range(50, 101);
            //        BattleManager.Instance.AddUnitinUnitList(battleUnit);
            //    }
            //}

            //if (Input.GetKeyDown(KeyCode.A))
            //{
            //    {
            //        GameManager.Instance.TryGetUnit(101, out Unit unit);

            //        if (BattleManager.BattleFactory.TryCreateBattleUnit(unit, false, out BattleUnit battleUnit))
            //        {
            //            battleUnit.Speed = Random.Range(50, 101);
            //            BattleManager.Instance.AddUnitinUnitList(battleUnit);
            //        }
            //    }
            //}
        }

        private void OnGUI()
        {
            if (GUI.Button(new Rect(10, 10, 100, 100), "전투 시작"))
            {
                List<Unit> units = GameManager.CurrentUser.userUnitDic.Values.ToList();

                GameManager.Instance.TryGetData<MapData>(500, out MapData mapData);

                SceneLoader.LoadBattleScene(units, mapData);
            }

            if (GUI.Button(new Rect(10, 120, 100, 100), "테스트용 유닛 넣기(1)"))
            {
                UserData userdata = GameManager.CurrentUser.userData;

                GameManager.Instance.TryGetUnit(100, out Unit unit);

                UserUnitData userUnitData = new UserUnitData(unit);
                userdata.unitDataList.Add(userUnitData);

                Debug.Log(GameManager.ItemCreator.CreateEquipmentItemData<WeaponData>(GradeType.Normal).attackPoint);

                userUnitData.weaponData = GameManager.ItemCreator.CreateEquipmentItemData<WeaponData>(GradeType.Normal);
                userUnitData.helmetData = GameManager.ItemCreator.CreateEquipmentItemData<HelmetData>(GradeType.Normal);
                userUnitData.armorData = GameManager.ItemCreator.CreateEquipmentItemData<ArmorData>(GradeType.Normal);
                userUnitData.shoeData = GameManager.ItemCreator.CreateEquipmentItemData<ShoeData>(GradeType.Normal);
                userUnitData.amuletData = GameManager.ItemCreator.CreateEquipmentItemData<AmuletData>(GradeType.Normal);
                userUnitData.RingData = GameManager.ItemCreator.CreateEquipmentItemData<RingData>(GradeType.Normal);

                SaveManager.SaveUserData(userdata);
            }

            if (GUI.Button(new Rect(120, 120, 100, 100), "테스트용 유닛 넣기(2)"))
            {
                UserData userdata = GameManager.CurrentUser.userData;
                GameManager.Instance.TryGetUnit(101, out Unit unit);

                UserUnitData userUnitData = new UserUnitData(unit);
                userdata.unitDataList.Add(userUnitData);

                userUnitData.weaponData = GameManager.ItemCreator.CreateEquipmentItemData<WeaponData>(GradeType.Normal);
                userUnitData.helmetData = GameManager.ItemCreator.CreateEquipmentItemData<HelmetData>(GradeType.Normal);
                userUnitData.armorData = GameManager.ItemCreator.CreateEquipmentItemData<ArmorData>(GradeType.Normal);
                userUnitData.shoeData = GameManager.ItemCreator.CreateEquipmentItemData<ShoeData>(GradeType.Normal);
                userUnitData.amuletData = GameManager.ItemCreator.CreateEquipmentItemData<AmuletData>(GradeType.Normal);
                userUnitData.RingData = GameManager.ItemCreator.CreateEquipmentItemData<RingData>(GradeType.Normal);

                SaveManager.SaveUserData(userdata);
            }

            if (GUI.Button(new Rect(10, 230, 100, 100), "유저 로드 데이터 테스트"))
            {
                UserData userdata = GameManager.CurrentUser.userData;
                Debug.Log($"" +
                    $"userID = {userdata.userID}\n" +
                    $"userName = {userdata.userName}\n");

                foreach (var userUnit in userdata.unitDataList)
                {
                    Debug.Log($"" +
                        $"userUnitID = {userUnit.unitID}");
                }
            }
        }
    }
}