using System;
using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public enum PlayerSolider
{
    Opossum,
    Bunny,
    Pig
}

/// <summary>
/// 購買的價目表
/// </summary>
public struct PayList
{
    public int levelOne;
    public int levelTwo;
    public int levelThree;
    public int levelFour;
    public int levelFive;
    public PayList(int a,int b ,int c,int d,int e)
    {
        levelOne = a;
        levelTwo = b;
        levelThree = c;
        levelFour = d;
        levelFive = e;
    }
    public int GetPrice(int level)
    {
        return level switch
        {
            1 => levelOne,
            2 => levelTwo,
            3 => levelThree,
            4 => levelFour,
            5 => levelFive,
            _ => 0
        };
    }
}

public class StorePanelController : MonoBehaviour
{
    public TMP_Text opossum;
    public Button upgade_os;
    public TMP_Text bunny;
    public Button upgade_bn;
    public TMP_Text pig;
    public Button upgade_pg;

    public TMP_Text MoneyText;


    public PayList OS_Paylist = new PayList(100,200,300,400,500);
    public PayList BN_Paylist = new PayList(100, 200, 300, 400,500);
    public PayList PG_Paylist = new PayList(100, 200, 300, 400,500);

    public TMP_Text OS_NeedMoney;
    public TMP_Text BN_NeedMoney;
    public TMP_Text PG_NeedMoney;

    public TMP_Text warningText;

    private void FixedUpdate()
    {
        StoreChangeText();
    }

    void StoreChangeText()
    {
        
        opossum.text = "opossum Lv" + GamePlayerMemory.OpossumLevel;
        upgade_os.interactable = GamePlayerMemory.OpossumLevel < 5;

        bunny.text = "bunny Lv" + GamePlayerMemory.BunnyLevel;
        upgade_bn.interactable = GamePlayerMemory.BunnyLevel < 5;

        pig.text = "pig Lv" + GamePlayerMemory.PigLevel;
        upgade_pg.interactable = GamePlayerMemory.PigLevel < 5;


        UpdateUpgradeCostText(GamePlayerMemory.OpossumLevel, OS_Paylist, OS_NeedMoney);
        UpdateUpgradeCostText(GamePlayerMemory.BunnyLevel, BN_Paylist, BN_NeedMoney);
        UpdateUpgradeCostText(GamePlayerMemory.PigLevel, PG_Paylist, PG_NeedMoney);

        MoneyText.text = "Money:" + GamePlayerMemory.CurrentMoney;
    }

    public void backButtonClick()
    {
        gameObject.SetActive(!gameObject.activeInHierarchy);
    }

    public void UpgradeOpossum() => Upgrade(PlayerSolider.Opossum);
    public void UpgradeBunny() => Upgrade(PlayerSolider.Bunny);
    public void UpgradePig() => Upgrade(PlayerSolider.Pig);


    public void Upgrade(PlayerSolider playersolider)
    {
        int currentMoney = GamePlayerMemory.CurrentMoney;

        switch (playersolider)
        {
            case PlayerSolider.Opossum:
                {
                    int level = GamePlayerMemory.OpossumLevel;
                    TryUpgrade(ref level, OS_Paylist, ref currentMoney);
                    GamePlayerMemory.SaveOpossumLV((CharactorLevel)level);
                    break;
                }
            case PlayerSolider.Bunny:
                {
                    int level = GamePlayerMemory.BunnyLevel;
                    TryUpgrade(ref level, BN_Paylist, ref currentMoney);
                    GamePlayerMemory.SaveBunnyLV((CharactorLevel)level);
                    break;
                }
            case PlayerSolider.Pig:
                {
                    int level = GamePlayerMemory.PigLevel;
                    TryUpgrade(ref level, PG_Paylist, ref currentMoney);
                    GamePlayerMemory.SavePigLV((CharactorLevel)level);
                    break;
                }
        }

        // 最後記得同步金錢
        PlayerPrefs.SetInt("CurrentMoney", currentMoney);
        PlayerPrefs.Save();
        StoreChangeText();
    }

    private bool TryUpgrade(ref int level, PayList payList, ref int money)
    {
        if (level >= 5) return false;

        int price = payList.GetPrice(level);
        if (money >= price)
        {
            money -= price;
            level++;
            Debug.Log($"升級成功，當前等級：{level}，剩餘金錢：{money}");
            return true;
        }
        else
        {
            Debug.Log("金錢不足，無法升級");
            ShowWarning("Money Not Enough");
            return false;
        }
    }
    private Coroutine warningCoroutine;

    void ShowWarning(string message)
    {
        if (warningCoroutine != null)
        {
            StopCoroutine(warningCoroutine);
        }
        warningCoroutine = StartCoroutine(ShowWarningCoroutine(message));
    }

    IEnumerator ShowWarningCoroutine(string message)
    {
        warningText.text = message;
        warningText.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);  // 顯示 2 秒
        warningText.gameObject.SetActive(false);
    }

    void UpdateUpgradeCostText(int currentLevel, PayList payList, TMP_Text text)
    {
        if (currentLevel >= 5)
        {
            text.text = "MAX";
        }
        else
        {
            int cost = payList.GetPrice(currentLevel); // 目前 Lv1 升級 → 用 levelOne 的價錢
            text.text = "Cost: " + cost;
        }
    }
}
