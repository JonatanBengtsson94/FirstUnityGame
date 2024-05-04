using UnityEngine;

public class EnemyAttack: MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] projectiles;
    private float timer;
   
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > attackCooldown)
        {
            Attack();
        }
    }

    private void Attack()
    {
        timer = 0;
        GetProjectile().transform.position = firePoint.position;
        GetProjectile().GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x), 0);
    }

    private GameObject GetProjectile()
    {
        foreach (var projectile in projectiles)
        {
            if (!projectile.activeInHierarchy)
            {
                return projectile;
            }
        }
        return null;
    }
}
