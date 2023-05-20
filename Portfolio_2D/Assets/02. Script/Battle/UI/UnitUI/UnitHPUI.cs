using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Portfolio
{
    public class UnitHPUI : MonoBehaviour
    {
        [SerializeField] Slider hpSlider;
        [SerializeField] TextMeshProUGUI hpText;
        
        public void SetHP(float maxHP)
        {
            hpSlider.maxValue = maxHP;
            hpSlider.value = maxHP;
            hpText.text = $"( {maxHP} / {maxHP} )";
        }

        public void ChangeHP(float currentHP)
        {
            hpSlider.value = currentHP;
            hpText.text = $"( {hpSlider.maxValue} / {currentHP} )";
        }
    }

}