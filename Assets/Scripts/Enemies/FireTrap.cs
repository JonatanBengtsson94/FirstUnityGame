using UnityEngine;

public class FireTrap : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private float activationTime;
    [SerializeField] private Damage damage;
    private float timer;
    private bool active;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (timer > activationTime)
        {
            active = !active;
            timer = 0;
            animator.SetBool("active", active);
            if (active)
            {
                damage.DamageAmount = 10;
            }
            else 
            {
                damage.DamageAmount = 0;
            }
        }
        timer += Time.deltaTime; 
    }
}
