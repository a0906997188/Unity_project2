using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// ���ת�enum
/// </summary>
public enum Difficulty
{
    Easy,
    Medium,
    Hard
}


/// <summary>
/// ���a���
/// </summary>
public static class GamePlayerMemory
{
    public static int MaxLevel { get; private set; }//�x�s�̤j�q���ơA�Ӷi�����d�[���A�}�����d�v��
    public static int CurrentMoney { get; private set; }//�x�s���a�������ƶq�A��K���Ӱ��X�ӫ��ƻ�

    /// <summary>
    /// ����q����ƪ���l�Ƥ�k
    /// </summary>
    public static void Init()
    {
        MaxLevel = PlayerPrefs.GetInt("MaxLevel", 0);
        CurrentMoney = PlayerPrefs.GetInt("CurrentMoney", 0);
        CurrentDifficulty = PlayerPrefs.GetInt("CurrentDifficulty", (int)Difficulty.Easy);
        BunnyLevel = PlayerPrefs.GetInt("BunnyLevel", 1);  // �T�O�o�̦����TŪ��
        OpssoumLevel = PlayerPrefs.GetInt("OppsoumLevel",1);
        PigLevel = PlayerPrefs.GetInt("PigLevel", 1);
        SetLevelCleared(0, Difficulty.Easy);

    }


    /// <summary>
    /// �W�[�����ƶq���R�A��k
    /// </summary>
    /// <param name="addMoney"></param>
    public static void AddMoney(int addMoney)
    {
        CurrentMoney += addMoney;
        PlayerPrefs.SetInt("CurrentMoney",CurrentMoney);
        PlayerPrefs.Save();
    }


    /// <summary>
    /// �x�s��e��ܪ�����
    /// </summary>
    public static int CurrentDifficulty { get; private set; }

    /// <summary>
    /// �]�m��ܪ�����
    /// </summary>
    /// <param name="difficulty"></param>
    public static void SetCurrentDIfficulty(Difficulty difficulty) 
    {
        CurrentDifficulty = (int)difficulty;
        PlayerPrefs.SetInt("CurrentDifficulty",CurrentDifficulty);//�x�s��e����
        PlayerPrefs.Save();
    }

    /// <summary>
    /// �x�sbunny������
    /// </summary>
    public static int BunnyLevel { get; private set; }
    /// <summary>
    /// �O�s��ebunny������
    /// </summary>
    /// <param name="BunnysLevel"></param>
    public static void SaveBunnyLV(CharactorLevel BunnysLevel)
    {
        PlayerPrefs.SetInt("BunnyLevel", (int)BunnysLevel);
        PlayerPrefs.Save();
    }

    /// <summary>
    /// �Ψ��x�sopssoum������
    /// </summary>
    public static int OpssoumLevel { get; private set; }
    
    public static void SaveOpssoumLV(CharactorLevel OpssoumLevel)
    {
        PlayerPrefs.SetInt("OppsoumLevel",(int)OpssoumLevel);
        PlayerPrefs.Save();
    }

    /// <summary>
    /// �x�spig������
    /// </summary>
    public static int PigLevel { get; private set; }
    public static void SavePigLV(CharactorLevel PigLevel)
    {
        PlayerPrefs.SetInt("PigLevel", (int)PigLevel);
        PlayerPrefs.Save();
    }
    /// <summary>
    /// �x�s�Y���Y���פw�q��
    /// </summary>
    public static void SetLevelCleared(int levelNumber, Difficulty difficulty)
    {
        string key = $"Level{levelNumber}_{difficulty}";
        PlayerPrefs.SetInt(key, 1); // 1�N��w�q��
        PlayerPrefs.Save();
    }

    /// <summary>
    /// �ˬd�Y���Y���׬O�_�w�q��
    /// </summary>
    public static bool IsLevelCleared(int levelNumber, Difficulty difficulty)
    {
        string key = $"Level{levelNumber}_{difficulty}";
        return PlayerPrefs.GetInt(key, 0) == 1;
    }


}
