using System.Collections.Generic;
using UnityEngine;

public class DebugTools : MonoBehaviour
{

    [ContextMenu("Log All PlayerPrefs")]
    public  void LogAllPrefs()
    {
        Debug.Log("MaxLevel: " + PlayerPrefs.GetInt("MaxLevel", -1));
        Debug.Log("CurrentMoney: " + PlayerPrefs.GetInt("CurrentMoney", -1));
        Debug.Log("CurrentDifficulty: " + PlayerPrefs.GetInt("CurrentDifficulty", -1));
        Debug.Log("BunnyLevel: " + PlayerPrefs.GetInt("BunnyLevel", -1));
    }
    
}
