using UnityEngine;

public class FireTrap : MonoBehaviour
{
    private Animator animator;
    private BoxCollider2D collider2D;
    [SerializeField] private float activationTime;
    private float timer;
    private bool active;

    void Awake()
    {
        animator = GetComponent<Animator>();
        collider2D = GetComponent<BoxCollider2D>();
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
                collider2D.enabled = true;
            }
            else 
            {
                collider2D.enabled = false;
            }
        }
        timer += Time.deltaTime; 
    }
}
