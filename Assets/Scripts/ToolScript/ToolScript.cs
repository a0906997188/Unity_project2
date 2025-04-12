using UnityEngine;

/// <summary>
/// 假如我定義一個工具製作
/// </summary>
public static class ToolScript
{
    /// <summary>
    /// 依據等級改變該數值
    /// </summary>
    /// <param name="value"></param>
    /// <param name="currentLevel"></param>
    /// <param name="level1"></param>
    /// <param name="level2"></param>
    /// <param name="level3"></param>
    /// <param name="level4"></param>
    /// <param name="level5"></param>
    public static void ChangeValueRelyOnLevel( out float value,CharactorLevel currentLevel,float level1,float level2,float level3,float level4,float level5)
    {
        switch (currentLevel)
        {
            case CharactorLevel.One:
                value = level1; 
                break;
            case CharactorLevel.Two:    value = level2; break;
            case CharactorLevel.Three:  value = level3; break;
            case CharactorLevel.Four:   value = level4; break;
            case CharactorLevel.Five:   value = level5; break;
            case CharactorLevel.Zero:   value = 0;      break;
            default:                    value = 0;      break;
        }
    }

    /// <summary>
    /// 依據難度改變該數值
    /// </summary>
    /// <param name="value"></param>
    /// <param name="currentDifficulty"></param>
    /// <param name="easyValue"></param>
    /// <param name="normalValue"></param>
    /// <param name="hardValue"></param>
    public static void AddPropertyRelyOnDifficulty(ref float value, Difficulty currentDifficulty, float easyValue, float normalValue, float hardValue)
    {
        switch (currentDifficulty)
        {
            case Difficulty.Easy:
                value += easyValue;
                break;
            case Difficulty.Medium:
                value += normalValue;
                break;
            case Difficulty.Hard:
                value += hardValue;
                break;
            default:
                break;
        }
    }

}
