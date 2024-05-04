using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int startingHealth;
    public int CurrentHealth { get; private set; }
    private Animator animator;

    private void Awake()
    {
        CurrentHealth = startingHealth;
        animator = GetComponent<Animator>();    
    }

    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
        if (CurrentHealth > 0)
        {
            animator.SetTrigger("hurt");
            CurrentHealth -= damage;

        } else 
        {
            animator.SetTrigger("die");
            GetComponent<PlayerMovement>().enabled = false;
        }
    }
}
