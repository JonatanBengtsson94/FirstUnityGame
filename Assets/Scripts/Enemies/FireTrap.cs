using UnityEngine;

public class FireTrap : MonoBehaviour
{
    private Animator animator;
    private BoxCollider2D fireCollider;
    [SerializeField] private float activationTime;
    private float timer;
    private bool active;

    void Awake()
    {
        animator = GetComponent<Animator>();
        fireCollider = GetComponent<BoxCollider2D>();
        fireCollider.enabled = false;
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
                fireCollider.enabled = true;
            }
            else 
            {
                fireCollider.enabled = false;
            }
        }
        timer += Time.deltaTime; 
    }
}
