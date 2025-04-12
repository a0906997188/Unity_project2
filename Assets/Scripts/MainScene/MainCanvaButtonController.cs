using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainCanvaButtonController : MonoBehaviour
{
    public GameObject ChoosePanel;//Choosepanel
    public GameObject ChooseLevelDropDown;//choosedropdown
    private TMP_Dropdown cld;

    private void Awake()
    {
        cld = ChooseLevelDropDown.GetComponent<TMP_Dropdown>();
        cld.value = GamePlayerMemory.CurrentDifficulty; // ��l�Ƨڪ����׿��
    }

    /// <summary>
    /// ���}choosepanel
    /// </summary>
    public void MainCanvaStartButton_Click()
    {
        if (transform.GetChild(1).gameObject.activeInHierarchy) GamePlayerMemory.SetCurrentDIfficulty(Difficulty.Easy);
        transform.GetChild(1).gameObject.SetActive(!ChoosePanel.activeInHierarchy);
    }
    /// <summary>
    /// �������ת��U�Կﶵ
    /// </summary>
    public void MainCanvaChooseDropDown_Click()
    {
        //��������
        switch (cld.value)
        {
            case 0:
                GamePlayerMemory.SetCurrentDIfficulty(Difficulty.Easy);
                print(GamePlayerMemory.CurrentDifficulty);
                break;
            case 1:
                GamePlayerMemory.SetCurrentDIfficulty(Difficulty.Medium);
                print(GamePlayerMemory.CurrentDifficulty);
                break;
            case 2:
                GamePlayerMemory.SetCurrentDIfficulty(Difficulty.Easy);
                print(GamePlayerMemory.CurrentDifficulty);
                break;

        }
    }


    public GameObject ErrorBox;
    public GameObject levelContent;
    private string SelectedLevelButtonName = null;
    public void SetSelectButton(Button a)
    {
        if (ErrorBox.activeInHierarchy)
        {
            ErrorBox.SetActive(!ErrorBox.activeInHierarchy);
        }
        SelectedLevelButtonName = a.name;
    }

    public void GoButton()
    {
        if(SelectedLevelButtonName != null)
        {
            
            SceneManager.LoadScene(SelectedLevelButtonName);
        }
        else
        {
            PleaseSelectLevel();
        }
    }

    //�p�G��������d
    public void PleaseSelectLevel()
    {
        ErrorBox.SetActive(!ErrorBox.activeInHierarchy);
    }
}
