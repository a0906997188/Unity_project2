using UnityEngine;
/// <summary>
/// 腳色的等級的列舉
/// </summary>
public enum CharactorLevel
{
    Zero = 0, One = 1, Two = 2, Three = 3,Four = 4,Five = 5
}

/// <summary>
/// 腳色類型有飛行及地面單位
/// </summary>
public enum CharactorType
{
    grounded = 0,
    sky=1
}


/// <summary>
/// 定義腳色的數值、等級的模板
/// </summary>
public abstract class CharactorBasic : MonoBehaviour
{
    /// <summary>
    /// 腳色等級
    /// </summary>
    public abstract CharactorLevel Level { get; set; }
    /// <summary>
    /// 腳色傷害
    /// </summary>
    public abstract float Damage {get ; }
    /// <summary>
    /// 腳色最大生命
    /// </summary>
    public abstract float MaxHealth {get ; }
    /// <summary>
    /// 腳色當前血量
    /// </summary>
    public abstract float CurrentHealth {get ; }
    /// <summary>
    /// 遊戲場景中，創建該兵種所需要的金錢
    /// </summary>
    public abstract float CreatMoney {get ; }
    /// <summary>
    /// 他是什麼單位?(地面或天空)
    /// </summary>
    public abstract CharactorType CharactorType { get; }
    
}

public interface CharactorAchievements
{

    /// <summary>
    /// 死亡
    /// </summary>
    public abstract void Die();
    /// <summary>
    /// 受傷
    /// </summary>
    /// <param name="damage"></param>
    public abstract void GetDamage(float damage);
    /// <summary>
    /// 造成對方攻擊
    /// </summary>
    /// <param name="damage"></param>
    public abstract void AttackDamage();
    /// <summary>
    /// 移動方法
    /// </summary>
    public abstract void Move(Transform a);
    /// <summary>
    /// 找到敵人的方法
    /// </summary>
    public abstract bool FindEnemy();
}

public abstract class player : CharactorBasic,CharactorAchievements
{
    public abstract void AttackDamage();
    public abstract void Die();
    public abstract bool FindEnemy();
    public abstract void GetDamage(float damage);
    public abstract void Move(Transform a);
}
public abstract class enemy : CharactorBasic, CharactorAchievements
{
    public abstract void init(CharactorLevel level);
    public abstract void AttackDamage();
    public abstract void Die();
    public abstract bool FindEnemy();
    public abstract void GetDamage(float damage);
    public abstract void Move(Transform a);
}


