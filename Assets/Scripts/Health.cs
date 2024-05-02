using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int startingHealth;
    private int currentHealth;
    private Animator animator;

    private void Awake()
    {
        currentHealth = startingHealth;
        animator = GetComponent<Animator>();    
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth > 0)
        {
            animator.SetTrigger("hurt");
            currentHealth -= damage;

        } else 
        {
            animator.SetTrigger("die");
            GetComponent<PlayerMovement>().enabled = false;
        }
    }
}
