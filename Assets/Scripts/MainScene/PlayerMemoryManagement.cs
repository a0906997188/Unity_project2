using UnityEngine;

public class PlayerMemoryManagement : MonoBehaviour
{
    public int currentLevel = 1;
    private void Awake()
    {
        GamePlayerMemory.Init();//��gameplayermemory���ƾڪ�l�ƪ���k
        DontDestroyOnLoad(gameObject);
    }
}
