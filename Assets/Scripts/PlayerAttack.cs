using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown = 1;
    private float cooldownTimer = Mathf.Infinity;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] bullets;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();        
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && cooldownTimer > attackCooldown)
        {
            Attack();
        }
        cooldownTimer += Time.deltaTime;
    }

    private void Attack()
    {
        animator.SetTrigger("attack");
        cooldownTimer = 0;

        GetBullet().transform.position = firePoint.position;
        GetBullet().GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
    }

    private GameObject GetBullet()
    {
        foreach (var bullet in bullets)
        {
            if (!bullet.activeInHierarchy)
            {
                return bullet;
            }
        }
        return null;
    }
}
