using Portfolio;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Portfolio.skill;
using System;
using Portfolio.condition;

namespace Portfolio
{
    public class GameManager : MonoBehaviour
    {
        //===========================================================
        // Singleton
        //===========================================================
        private static GameManager instance;
        public static GameManager Instance { get => instance; }

        //===========================================================
        // Dictionary
        //===========================================================
        private Dictionary<int, Data> dataDictionary = new Dictionary<int, Data>();
        private Dictionary<int, Unit> unitDictionary = new Dictionary<int, Unit>();
        private Dictionary<int, Skill> skillDictionary = new Dictionary<int, Skill>();
        private Dictionary<int, Condition> conditionDictionary = new Dictionary<int, Condition>();

        public bool isTest;

        //===========================================================
        // UserData
        //===========================================================
        public static UserData CurrentUser;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }

            ResourcesLoader.LoadAllData(dataDictionary);
            CreateGameSource();

            if (!SaveManager.LoadUserData(out CurrentUser))
            {
                CurrentUser = SaveManager.CreateNewUser();
            }
        }

        private void Start()
        {
            if (!isTest)
            {
                Debug.LogWarning("GameManager Test");
            }
        }

        public bool TryGetData<T>(int ID, out T data) where T : Data
        {
            if (!dataDictionary.ContainsKey(ID))
            {
                Debug.LogWarning("KeyValue is not Contains");
                data = null;
                return false;
            }

            if (!(dataDictionary[ID] is T))
            {
                Debug.LogWarning("Value is not " + typeof(T).Name);
                data = null;
                return false;
            }

            data = dataDictionary[ID] as T;
            return true;
        }

        public List<T> GetDatas<T>() where T : Data
        {
            var list = dataDictionary.Values.Where((data) => data is T).Select(kv => kv as T).ToList();

            return list;
        }

        public bool TryGetUnit(int ID, out Unit unit)
        {
            if (!unitDictionary.ContainsKey(ID))
            {
                Debug.LogWarning(ID + " is not Contains");
                unit = null;
                return false;
            }

            unit = unitDictionary[ID];
            return true;
        }

        public bool TryGetCondition(int ID, out Condition condition)
        {
            if (!conditionDictionary.ContainsKey(ID))
            {
                Debug.LogWarning(ID + " is not Contains");
                condition = null;
                return false;
            }

            condition = conditionDictionary[ID];
            return true;
        }

        public bool TryGetSkill<T>(int ID, out T skill) where T : Skill
        {
            if (!skillDictionary.ContainsKey(ID))
            {
                Debug.LogWarning(ID + " is not Contains");
                skill = null;
                return false;
            }

            if (!(skillDictionary[ID] is T))
            {
                Debug.LogWarning("Value is not " + typeof(T).Name);
                skill = null;
                return false;
            }

            skill = skillDictionary[ID] as T;
            return true;
        }

        #region 데이터를 형식으로 변환

        private void CreateGameSource()
        {
            LoadSkill();
            LoadUnit();
            LoadCondition();
        }

        private void LoadUnit()
        {
            foreach (var data in GetDatas<UnitData>())
            {
                unitDictionary.Add(data.ID, new Unit((UnitData)data));
            }
        }

        private void LoadSkill()
        {
            foreach (var data in GetDatas<SkillData>())
            {
                SkillData skillData = (data as SkillData);
                //Debug.Log((data as SkillData).skillClassName);
                var type = Type.GetType("Portfolio.skill." + (data as SkillData).skillClassName);
                //Debug.Log(type);
                object obj = null;
                switch (skillData.skillType)
                {
                    case SkillType.ActiveSkill:
                        {
                            obj = Activator.CreateInstance(type, skillData as ActiveSkillData);
                            skillDictionary.Add(data.ID, obj as ActiveSkill);
                        }
                        break;
                    case SkillType.PassiveSkill:
                        {
                            obj = Activator.CreateInstance(type, skillData as PassiveSkillData);
                            skillDictionary.Add(data.ID, obj as PassiveSkill);
                        }
                        break;
                }
            }
        }

        private void LoadCondition()
        {
            foreach (var data in GetDatas<ConditionData>())
            {
                var type = Type.GetType("Portfolio.condition." + (data as ConditionData).conditionClassName);
                object obj = Activator.CreateInstance(type, data as ConditionData);
                conditionDictionary.Add(data.ID, obj as Condition);
            }
        }
        #endregion
    }
}