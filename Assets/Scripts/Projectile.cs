using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private int speed = 10;
    private bool hit;
    private float direction;
    private float lifetime;
    private Animator animator;
    private BoxCollider2D boxCollider;

    void Awake()
    {
        animator = GetComponent<Animator>();        
        boxCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
       if (hit)
       {
            return;
       } 
       float movementSpeed = speed * Time.deltaTime * direction;
       transform.Translate(movementSpeed, 0, 0);

       lifetime += Time.deltaTime;
       if (lifetime > 3)
       {
            gameObject.SetActive(false);
       }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        hit = true;
        boxCollider.enabled = false;
        animator.SetTrigger("hit");
    }

    public void SetDirection(float _direction) 
    {
        lifetime = 0;
        direction = _direction;
        gameObject.SetActive(true);
        hit = false;
        boxCollider.enabled = true;

        float localScaleX = transform.localScale.x;
        if (Math.Sign(localScaleX) != _direction)
        {
            localScaleX = -localScaleX;
        }

        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    }

    private void Deactivate() 
    {
        gameObject.SetActive(false);
    }
}
