using System;
using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

[Serializable]
public class EnemyComing
{
    [SerializeField] public GameObject[] enemyObject;
    [SerializeReference] public CharactorLevel lv;
    [SerializeField] public int people; // 該波次的人數
    [SerializeField] public float PerTime = 0.5f;

}

public class BattleController : MonoBehaviour
{
    public EnemyComing[] ListEnemy;
    public GameObject[] EnemyInstancePoint;
    public static BattleController instance;

    public int enemyCurrentNumber;     // 場上活著的敵人數量
    private int spawnedEnemyCount;     // 已生成的敵人數量
    private int totalEnemyCount;       // 該波敵人的總數
    public int WinMoney = 1000;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }
    public int HP= 3;
    private void FixedUpdate()
    {
        if (instance.HP <= 0)
        {
            Lose();
        }
    }



    IEnumerator SpawnEnemies()
    {
        EnemyComing enemyWave = ListEnemy[0];

        totalEnemyCount = enemyWave.people;
        spawnedEnemyCount = 0;
        enemyCurrentNumber = 0;

        Debug.Log($"開始生成一波敵人，共 {totalEnemyCount} 人");

        for (int i = 0; i < totalEnemyCount; i++)
        {
            int spawnPointIndex = UnityEngine.Random.Range(0, EnemyInstancePoint.Length);
            Transform spawnPoint = EnemyInstancePoint[spawnPointIndex].transform;

            int enemyIndex = UnityEngine.Random.Range(0, enemyWave.enemyObject.Length);
            GameObject enemyPrefab = enemyWave.enemyObject[enemyIndex];

            GameObject newEnemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);

            if (newEnemy.TryGetComponent(out enemy e))
            {
                e.init(enemyWave.lv);
            }

            spawnedEnemyCount++;
            enemyCurrentNumber++;
            yield return new WaitForSeconds(enemyWave.PerTime);
        }

        Debug.Log("敵人全部生成完畢，等待全數擊殺...");

        yield return new WaitUntil(() =>
            spawnedEnemyCount == totalEnemyCount && enemyCurrentNumber == 0
        );

        Debug.Log(" 所有敵人已擊敗，玩家獲勝！");
        Victory();
    }

    public GameObject WinPanel;
    public void Victory()
    {
        WinPanel.SetActive(true);
    }

    public GameObject LosePanel;
    public void Lose()
    {
        LosePanel.SetActive(true);
    }
}

