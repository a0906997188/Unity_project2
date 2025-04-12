using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// 難度的enum
/// </summary>
public enum Difficulty
{
    Easy,
    Medium,
    Hard
}


/// <summary>
/// 玩家資料
/// </summary>
public static class GamePlayerMemory
{
    public static int MaxLevel { get; private set; }//儲存最大通關數，來進行關卡加載，開放關卡權限
    public static int CurrentMoney { get; private set; }//儲存玩家的金錢數量，方便未來做出商城甚麼的

    /// <summary>
    /// 獲取電腦資料的初始化方法
    /// </summary>
    public static void Init()
    {
        MaxLevel = PlayerPrefs.GetInt("MaxLevel", 0);
        CurrentMoney = PlayerPrefs.GetInt("CurrentMoney", 0);
        CurrentDifficulty = PlayerPrefs.GetInt("CurrentDifficulty", (int)Difficulty.Easy);
        BunnyLevel = PlayerPrefs.GetInt("BunnyLevel", 1);  // 確保這裡有正確讀取
        OpssoumLevel = PlayerPrefs.GetInt("OppsoumLevel",1);
        PigLevel = PlayerPrefs.GetInt("PigLevel", 1);
        SetLevelCleared(0, Difficulty.Easy);

    }


    /// <summary>
    /// 增加金錢數量的靜態方法
    /// </summary>
    /// <param name="addMoney"></param>
    public static void AddMoney(int addMoney)
    {
        CurrentMoney += addMoney;
        PlayerPrefs.SetInt("CurrentMoney",CurrentMoney);
        PlayerPrefs.Save();
    }


    /// <summary>
    /// 儲存當前選擇的難度
    /// </summary>
    public static int CurrentDifficulty { get; private set; }

    /// <summary>
    /// 設置選擇的難度
    /// </summary>
    /// <param name="difficulty"></param>
    public static void SetCurrentDIfficulty(Difficulty difficulty) 
    {
        CurrentDifficulty = (int)difficulty;
        PlayerPrefs.SetInt("CurrentDifficulty",CurrentDifficulty);//儲存當前難度
        PlayerPrefs.Save();
    }

    /// <summary>
    /// 儲存bunny的等級
    /// </summary>
    public static int BunnyLevel { get; private set; }
    /// <summary>
    /// 保存當前bunny的等級
    /// </summary>
    /// <param name="BunnysLevel"></param>
    public static void SaveBunnyLV(CharactorLevel BunnysLevel)
    {
        PlayerPrefs.SetInt("BunnyLevel", (int)BunnysLevel);
        PlayerPrefs.Save();
    }

    /// <summary>
    /// 用來儲存opssoum的等級
    /// </summary>
    public static int OpssoumLevel { get; private set; }
    
    public static void SaveOpssoumLV(CharactorLevel OpssoumLevel)
    {
        PlayerPrefs.SetInt("OppsoumLevel",(int)OpssoumLevel);
        PlayerPrefs.Save();
    }

    /// <summary>
    /// 儲存pig的等級
    /// </summary>
    public static int PigLevel { get; private set; }
    public static void SavePigLV(CharactorLevel PigLevel)
    {
        PlayerPrefs.SetInt("PigLevel", (int)PigLevel);
        PlayerPrefs.Save();
    }
    /// <summary>
    /// 儲存某關某難度已通關
    /// </summary>
    public static void SetLevelCleared(int levelNumber, Difficulty difficulty)
    {
        string key = $"Level{levelNumber}_{difficulty}";
        PlayerPrefs.SetInt(key, 1); // 1代表已通關
        PlayerPrefs.Save();
    }

    /// <summary>
    /// 檢查某關某難度是否已通關
    /// </summary>
    public static bool IsLevelCleared(int levelNumber, Difficulty difficulty)
    {
        string key = $"Level{levelNumber}_{difficulty}";
        return PlayerPrefs.GetInt(key, 0) == 1;
    }


}
