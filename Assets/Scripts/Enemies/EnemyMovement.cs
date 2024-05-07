using UnityEngine;

public class EnemyMovement: MonoBehaviour
{
    [SerializeField] private float moveDistance;
    [SerializeField] private float moveSpeed;
    private float startingXPos;
    private bool movingRight;

    private void Start()
    {
        startingXPos = transform.position.x;
        transform.localScale = new Vector3(-1 ,1 ,1);
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
                transform.localScale = new Vector3(-1 ,1 ,1);
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
                transform.localScale = Vector3.one;
            }
        }
    }
}
