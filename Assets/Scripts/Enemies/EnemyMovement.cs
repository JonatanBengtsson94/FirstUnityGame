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
