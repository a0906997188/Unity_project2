using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
using System.Linq;
using TMPro;

public class LevelButtonManager : MonoBehaviour
{

    [SerializeField] private TMP_Dropdown difficultyDropdown; // 指向 Difficulty 的 Dropdown
    void OnEnable()
    {
        RefreshLevelButtons();
    }

    void RefreshLevelButtons()
    {
        // 搜尋所有子物件裡的 Button
        Button[] levelButtons = GetComponentsInChildren<Button>();
        for(int i = 0; i < levelButtons.Length; i++)
        {
            levelButtons[i].interactable = GamePlayerMemory.IsLevelCleared(i, Difficulty.Easy);
        }
    }
}
