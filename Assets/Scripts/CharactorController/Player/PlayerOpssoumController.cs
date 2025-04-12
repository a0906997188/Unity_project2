using UnityEngine;

public class PlayerOpssoumController : player
{
    public Animator anim;
    private void Start()
    {
        Init_Charactor();
    }

    private void FixedUpdate()
    {
        AttackDamage();
        Move(TargetPosition);
        if (transform.position.x > 8) Die();

    }

    /// <summary>
    /// 創建該兵後，進行初始化
    /// </summary>
    void Init_Charactor()
    {
        lv = (CharactorLevel)GamePlayerMemory.OpossumLevel;
        ToolScript.ChangeValueRelyOnLevel(out Attack, lv, 12, 14, 18, 24, 32);
        ToolScript.ChangeValueRelyOnLevel(out maxHealth, lv, 60, 70, 80, 100, 120);
        ToolScript.ChangeValueRelyOnLevel(out creatMoney, lv, 15, 15, 15, 18, 18);
        currentHealth = MaxHealth;
    }

    /// <summary>
    /// 他是地面單位
    /// </summary>
    public CharactorType CT = CharactorType.grounded;
    public override CharactorType CharactorType => CT;

    /// <summary>
    /// 等級
    /// </summary>
    public CharactorLevel lv = CharactorLevel.One;
    public override CharactorLevel Level { get => lv;set { lv = value; } }

    /// <summary>
    /// 攻擊力
    /// </summary>
    public float Attack;
    public override float Damage => Attack;

    /// <summary>
    /// 最大血量
    /// </summary>
    public float maxHealth;
    public override float MaxHealth => maxHealth;

    /// <summary>
    /// 當前血量
    /// </summary>
    public float currentHealth;
    public override float CurrentHealth => currentHealth;

    public float creatMoney;
    public override float CreatMoney => creatMoney;

    public override void AttackDamage()
    {
        bool a = FindEnemy();
        anim.SetBool("isAttack", a);
    }

    public override void Die()
    {
        Destroy(this.gameObject);
    }

    public override bool FindEnemy()
    {
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, Vector2.right, 1.2f);
        foreach (var hit in hits)
        {
            if (hit.collider.gameObject.CompareTag("Enemy"))
            {
                return true;
            }
        }
        return false;
    }

    public override void GetDamage(float damage)
    {
        this.currentHealth -= damage;
        if (this.currentHealth <= 0) Die();
    }

    public Transform TargetPosition;
    public float speed = 2.5f;

    public override void Move(Transform a)
    {
        if (!FindEnemy())
        {
            transform.position += new Vector3(speed, 0) * Time.fixedDeltaTime;
        }
    }
}
