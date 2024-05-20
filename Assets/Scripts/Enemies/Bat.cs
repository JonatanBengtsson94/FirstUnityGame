using UnityEngine;

public class Bat : MonoBehaviour
{
  private Vision vision;
  private EnemyMovement movement;
  [SerializeField] private BoxCollider2D boxCollider;

    void Awake()
    {
      boxCollider = GetComponent<BoxCollider2D>();
      movement = GetComponentInParent<EnemyMovement>();
      vision = GetComponent<Vision>();
    }

    void Update()
    {
      if (vision.PlayerInSight(boxCollider, 10))
      {
        movement.enabled = true;
      } 
      else
      {
        movement.enabled = false;
      }
        
    }

    private void OnDrawGizmos()
    {
      Gizmos.color = Color.red;
      Gizmos.DrawWireCube(
        boxCollider.bounds.center + new Vector3(5 / 2 * (transform.localScale.x), 0, 0),
        new Vector3(boxCollider.bounds.size.x - 5, boxCollider.bounds.size.y + 10, boxCollider.bounds.size.z)
      );
    }
}
