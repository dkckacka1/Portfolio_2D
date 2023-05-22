using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Portfolio.Editor
{
    public class TableLoader 
    {
        [MenuItem("Tools/Json/CheckValidJson")]
        private static void CheckValidJson()
        {
            Debug.Log(TableToJson.CheckValidJson());
        }

        [MenuItem("Tools/Json/CreateSkillTable")]
        private static void TestMethod()
        {
            Debug.Log(TableToJson.GetSkillTable());
        }
    } 
}
