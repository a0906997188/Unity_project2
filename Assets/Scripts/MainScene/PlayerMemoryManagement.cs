using UnityEngine;

public class PlayerMemoryManagement : MonoBehaviour
{
    public int currentLevel = 1;
    private void Awake()
    {
        GamePlayerMemory.Init();//讓gameplayermemory的數據初始化的方法
        DontDestroyOnLoad(gameObject);
    }
}
