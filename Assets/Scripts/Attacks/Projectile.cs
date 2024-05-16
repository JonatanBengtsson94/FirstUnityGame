using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private int speed = 10;
    [SerializeField] private float maxLifetime;
    private float lifetime;
    private bool hit;
    private Animator animator;
    private BoxCollider2D boxCollider;
    private Rigidbody2D body;

    void Awake()
    {
        animator = GetComponent<Animator>();        
        boxCollider = GetComponent<BoxCollider2D>();
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (hit)
            {
                return;
            } 

            lifetime += Time.deltaTime;
            if (lifetime > maxLifetime)
            {
                gameObject.SetActive(false);
            }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        hit = true;
        boxCollider.enabled = false;
        animator.SetTrigger("hit");
        body.velocity = Vector2.zero;
    }

    public void SetDirection(float _direction, float angle) 
    {
        lifetime = 0;
        gameObject.SetActive(true);
        hit = false;
        boxCollider.enabled = true;

        float localScaleX = transform.localScale.x;
        if (Mathf.Sign(localScaleX) != _direction)
        {
            localScaleX = -localScaleX;
        }

        transform.localScale = new Vector3(localScaleX, 1, 1);
        body.velocity = new Vector2(speed * localScaleX, speed * angle);
    }

    private void Deactivate() 
    {
        gameObject.SetActive(false);
    }
}
