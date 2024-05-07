using UnityEngine;

public class Lizard : MonoBehaviour
{
    [SerializeField] private RangedAttack fireballAttack;
    [SerializeField] private float range;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private float attackCooldown;
    private float timer;
    private Animator animator;
    private EnemyMovement movement;


    void Awake()
    {
        animator = GetComponent<Animator>();
        movement = GetComponentInParent<EnemyMovement>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (PlayerInSight())
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

    private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(
            boxCollider.bounds.center + new Vector3(range / 2 * transform.localScale.x, 0, 0),
            new Vector3(boxCollider.bounds.size.x + range , boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0,
            Vector2.left,
            0,
            playerLayer
        );
        
        return hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(
            boxCollider.bounds.center + new Vector3(range / 2 * (transform.localScale.x), 0, 0),
            new Vector3(boxCollider.bounds.size.x + range , boxCollider.bounds.size.y, boxCollider.bounds.size.z)
        );

    }
}
