using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header ("Health")]
    [SerializeField] private int startingHealth;
    public int CurrentHealth { get; private set; }
    private Animator animator;
    [Header ("Invulnerability")]
    [SerializeField] private float invulnerabilityTime;
    [SerializeField] private int numOfFlashes;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        CurrentHealth = startingHealth;
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
        if (CurrentHealth > 0)
        {
            animator.SetTrigger("hurt");
            StartCoroutine(Invunerability());

        } else 
        {
            animator.SetTrigger("die");
            GetComponent<PlayerMovement>().enabled = false;
        }
    }

    public void Heal(int healAmount)
    {
        CurrentHealth += healAmount;
    }

    private IEnumerator Invunerability()
    {
        Physics2D.IgnoreLayerCollision(7, 8, true);
        for (int i = 0; i < numOfFlashes; i++)
        {
            spriteRenderer.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(invulnerabilityTime / (numOfFlashes * 2));
            spriteRenderer.color = Color.white;
            yield return new WaitForSeconds(invulnerabilityTime / (numOfFlashes * 2));
        }

        Physics2D.IgnoreLayerCollision(7, 8, false);
    }
}