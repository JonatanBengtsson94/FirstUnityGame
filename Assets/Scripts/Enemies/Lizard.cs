using UnityEngine;

public class Lizard : MonoBehaviour
{
    [SerializeField] private RangedAttack fireballAttack;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private float attackCooldown;
    private float timer;
    private Animator animator;
    private EnemyMovement movement;
    private Vision vision;

    void Awake()
    {
        animator = GetComponent<Animator>();
        movement = GetComponentInParent<EnemyMovement>();
        vision = GetComponent<Vision>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (vision.PlayerInSight(boxCollider, 0))
        {
            movement.enabled = false;
            if (timer > attackCooldown)
            {
                animator.SetTrigger("playerSighted");
                timer = 0;
            }
        }
        else
        {
            movement.enabled = true;
        } 
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(
            boxCollider.bounds.center + new Vector3(5 / 2 * (transform.localScale.x), 0, 0),
            new Vector3(boxCollider.bounds.size.x - 5, boxCollider.bounds.size.y, boxCollider.bounds.size.z)
        );

    }

}
