using UnityEngine;

public class FireTrap : MonoBehaviour
{
    [SerializeField] private int damage;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private float activationTime;
    private float timer;
    private bool active;

    void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (timer > activationTime)
        {
            active = !active;
            timer = 0;
            animator.SetBool("active", active);
        }
        timer += Time.deltaTime; 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (active)
        {
            collision.GetComponent<Health>().TakeDamage(damage);
        }
    }
}
