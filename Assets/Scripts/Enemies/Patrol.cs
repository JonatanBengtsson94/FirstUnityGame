using UnityEngine;

public class Patrol : MonoBehaviour
{
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;
    [SerializeField] private float moveSpeed;
    private float xmin;
    private float xmax;
    private bool movingRight = true;

    private void Start()
    {
        transform.localScale = new Vector3(1 ,1 ,1);
        xmin = leftEdge.transform.position.x;
        xmax = rightEdge.transform.position.x;    
    }


    private void Update()
    {
        if (movingRight)
        {
            if (transform.position.x < xmax)
            {
                transform.position = new Vector3(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y, transform.position.z);
            } 
            else 
            {
                movingRight = false;
                transform.localScale = new Vector3(-1 ,1 ,1);
            }
        } 
        else
        {
            if (transform.position.x > xmin) 
            {
                transform.position = new Vector3(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y, transform.position.z);
            } 
            else
            {
                movingRight = true;
                transform.localScale = Vector3.one;
            }
        }
    }
}
