using System.Collections;
using UnityEngine;

public class PlayerHealth : Health 
{
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

    public override void TakeDamage(int damage)
    {
        CurrentHealth = Mathf.Clamp(CurrentHealth - damage, 0, startingHealth);
        if (CurrentHealth > 0)
        {
            animator.SetTrigger("hurt");
            StartCoroutine(Invunerability());

        } else 
        {
            FindObjectOfType<GameManager>().GameOver();
            //Destroy(gameObject);
        }
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
