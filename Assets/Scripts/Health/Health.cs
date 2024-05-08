using UnityEngine;

public class Health : MonoBehaviour
{
    [Header ("Health")]
    [SerializeField] protected int startingHealth;
    public int CurrentHealth { get; protected set; }
    protected Animator animator;

    private void Awake()
    {
        CurrentHealth = startingHealth;
        animator = GetComponent<Animator>();
    }

    public virtual void TakeDamage(int damage)
    {
        CurrentHealth = Mathf.Clamp(CurrentHealth - damage, 0, startingHealth);
        if (CurrentHealth > 0)
        {
            animator.SetTrigger("hurt");

        } else 
        {
            Destroy(gameObject);
        }
    }

    public void Heal(int healAmount)
    {
        CurrentHealth = Mathf.Clamp(CurrentHealth + healAmount, 0, startingHealth);
    }
}
