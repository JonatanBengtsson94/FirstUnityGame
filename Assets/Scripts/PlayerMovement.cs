using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    private Animator animator;
    private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private int speed = 5; 

    private void Awake() 
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);
        
        // Jump
        if(Input.GetKey(KeyCode.Space) && IsGrounded()) 
        {
            Jump();
        }

        // Flip character when based on direction
        if(horizontalInput > 0) 
        {
            transform.localScale = Vector3.one;
        } else if (horizontalInput < 0)  
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        // Set animator parameters
        animator.SetBool("run", horizontalInput != 0);
        animator.SetBool("grounded", IsGrounded());
    }

    private void Jump() 
    { 
        body.velocity = new Vector2(body.velocity.x, speed); 
        animator.SetTrigger("jump");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }
}
