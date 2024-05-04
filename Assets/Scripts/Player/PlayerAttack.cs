using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private enum Weapon
    {
        Gun,
        Bomb
    }
    [SerializeField] private Weapon equippedWeapon;
    [SerializeField] private float attackCooldown = 1;
    private float cooldownTimer = Mathf.Infinity;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] bullets;
    [SerializeField] private GameObject bomb;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();        
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && cooldownTimer > attackCooldown)
        {
            Attack(equippedWeapon);
        }
        cooldownTimer += Time.deltaTime;
    }

    private void Attack(Weapon weapon)
    {
        animator.SetTrigger("attack");
        cooldownTimer = 0;

        switch (weapon)
        {
            case Weapon.Gun:
                GetBullet().transform.position = firePoint.position;
                GetBullet().GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x), 0);
                break;
            case Weapon.Bomb:
                bomb.transform.position = firePoint.position;
                bomb.GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x), 1);
                break;
 
        } 
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
