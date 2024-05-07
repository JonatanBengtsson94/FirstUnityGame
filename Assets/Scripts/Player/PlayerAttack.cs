using UnityEngine;

public class PlayerAttack: MonoBehaviour
{
    protected Animator animator;
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
        if (Input.GetMouseButton(0) && gunTimer > gunCooldown)
        {
            FireGun();
            gunTimer = 0;
        }
        if (Input.GetMouseButton(1) && bombTimer > bombCooldown)
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
