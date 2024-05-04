using System.Runtime.InteropServices;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    private Animator animator;
    private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float speed;
    [SerializeField] private float jumpPower; 
    private float horizontalInput;
    private bool jump;

    private void Awake() 
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal") * speed;
        
        // Jump
        if(Input.GetKey(KeyCode.Space) && IsGrounded()) 
        {
           jump = true; 
        }
    }

    private void FixedUpdate()
    {
        Move(horizontalInput);
    }

    private void Move(float move)
    {
        body.velocity = new Vector2(move * Time.fixedDeltaTime, body.velocity.y);
        
        // Flip character when based on direction
        if(move > 0) 
        {
            transform.localScale = Vector3.one;
        } else if (move < 0)  
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        // Set animator parameters
        animator.SetBool("run", move != 0);
        animator.SetBool("grounded", IsGrounded());

        if (jump)
        {
            body.velocity = new Vector2(body.velocity.x, jumpPower); 
            animator.SetTrigger("jump");
        }
        jump = false;
    }


    private bool IsGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }
}
