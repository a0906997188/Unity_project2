using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
using System.Linq;
using TMPro;

public class LevelButtonManager : MonoBehaviour
{

    [SerializeField] private TMP_Dropdown difficultyDropdown; // ���V Difficulty �� Dropdown
    void OnEnable()
    {
        RefreshLevelButtons();
    }

    void RefreshLevelButtons()
    {
        // �j�M�Ҧ��l����̪� Button
        Button[] levelButtons = GetComponentsInChildren<Button>();
        for(int i = 0; i < levelButtons.Length; i++)
        {
            levelButtons[i].interactable = GamePlayerMemory.IsLevelCleared(i, Difficulty.Easy);
        }
    }
}
