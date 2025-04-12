using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartCanvaButtonController : MonoBehaviour
{
    public GameObject StartgamePanel;
    public GameObject AreYouSurePanel;
    public GameObject BattaleController;
    public void ImReadyButton_Click()
    {
        StartgamePanel.SetActive(!StartgamePanel.activeInHierarchy);
        BattaleController.SetActive(true);
    }
    public void AreSure_NoButtonClick()
    {
        AreYouSurePanel.SetActive(!AreYouSurePanel.activeInHierarchy);
    }
    public void AreSure_YesButtonClick()
    {
        SceneManager.LoadScene(0);
    }

    public void WinReturnButton()
    {   string a= SceneManager.GetActiveScene().name;
        string b = a.Substring(6, a.Length);
        GamePlayerMemory.SetLevelCleared(Convert.ToInt32(b), (Difficulty)GamePlayerMemory.CurrentDifficulty);
        SceneManager.LoadScene("MainScene");
    }
    
    public void loseRestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void loseReturnButton()
    {
        SceneManager.LoadScene("MainScene");
    }
}
