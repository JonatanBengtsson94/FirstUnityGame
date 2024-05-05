using UnityEngine;

public class CannonTrapAttack: MonoBehaviour
{
    [SerializeField] private RangedAttack fireballAttack;
    [SerializeField] private float attackCooldown;
    private float timer;
   
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > attackCooldown)
        {
            fireballAttack.Attack(0);
            timer = 0;
        }
    }
}
