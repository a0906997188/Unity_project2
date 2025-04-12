using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackCharctorAnimContriller : MonoBehaviour
{
    Collider2D coll;
    enemy p;
    bool hasAttacked = false; // 攻擊旗標

    private void Awake()
    {
        coll = GetComponent<Collider2D>();
        coll.enabled = false;
        p = transform.parent.GetComponent<enemy>();
    }

    public void AttackRangeAppearOrDispear()
    {
        coll.enabled = !coll.enabled;

        if (coll.enabled)
        {
            hasAttacked = false; // 攻擊範圍打開，準備攻擊
        }
    }

    List<Collider2D> colliders = new List<Collider2D>();

    private void FixedUpdate()
    {
        if (coll.enabled && !hasAttacked && colliders.Count > 0)
        {
            // 找最左邊敵人
            Collider2D MostLeftInColliders = colliders[0];
            foreach (var c in colliders)
            {
                if (c != null && c.transform.position.x < MostLeftInColliders.transform.position.x)
                {
                    MostLeftInColliders = c;
                }
            }

            // 攻擊一次
            player targetEnemy = MostLeftInColliders.GetComponent<player>();
            if (targetEnemy != null)
            {
                targetEnemy.GetDamage(p.Damage);
            }

            hasAttacked = true; // 記錄已攻擊，避免重複
        }

        colliders.Clear();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayersSolider"))
        {
            colliders.Add(collision);
        }
    }
}
