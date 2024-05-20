using UnityEngine;

public class Charge: EnemyMovement 
{
  [SerializeField] private Transform player;  
  private Vector3 targetPos = Vector3.zero;

  void Update()
  {
    targetPos = new Vector3(player.position.x, player.position.y, transform.position.z);
    transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
  }
}
