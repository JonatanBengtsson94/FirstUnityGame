using UnityEngine;

public class Enemy_Sideways : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private float moveDistance;
    [SerializeField] private float moveSpeed;
    private float startingXPos;
    private bool movingRight;

    private void Awake()
    {
        startingXPos = transform.position.x;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Health>().TakeDamage(damage);
        }
    }

    private void Update()
    {
        if (movingRight)
        {
            if (transform.position.x < startingXPos + moveDistance)
            {
                transform.position = new Vector3(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y, transform.position.z);
            } 
            else 
            {
                movingRight = false;
            }
        } 
        else
        {
            if (transform.position.x > startingXPos - moveDistance) 
            {
                transform.position = new Vector3(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y, transform.position.z);
            } 
            else
            {
                movingRight = true;
            }
        }
    }
}
