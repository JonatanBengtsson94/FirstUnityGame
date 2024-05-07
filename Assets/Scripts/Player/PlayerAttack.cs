using UnityEngine;

public class PlayerAttack: MonoBehaviour
{
    private Animator animator;
    [Header("Gun attack")]
    [SerializeField] private float gunCooldown;

    [SerializeField] RangedAttack gunAttack;
    [Header("Bomb attack")]
    [SerializeField] RangedAttack bombAttack; 
    [SerializeField] private float bombCooldown;
    private float gunTimer, bombTimer; 

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        gunTimer += Time.deltaTime;
        bombTimer += Time.deltaTime;
        if (Input.GetButtonDown("Fire1") && gunTimer > gunCooldown)
        {
            FireGun();
            gunTimer = 0;
        }
        if (Input.GetButtonDown("Fire2") && bombTimer > bombCooldown)
        {
            ThrowBomb();
            bombTimer = 0;
        }
    }

    private void ThrowBomb()
    {
        bombAttack.Attack(1);
    }

    private void FireGun()
    {
        animator.SetTrigger("shoot");
        gunAttack.Attack(0);
    }
}
