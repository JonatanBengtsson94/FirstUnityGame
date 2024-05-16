using UnityEngine;

public class Vision : MonoBehaviour
{
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private float visionRange;

    public bool PlayerInSight(BoxCollider2D boxCollider)
    {
        RaycastHit2D hit = Physics2D.BoxCast(
            boxCollider.bounds.center + new Vector3(visionRange/ 2 * transform.localScale.x, 0, 0),
            new Vector3(boxCollider.bounds.size.x + visionRange, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0,
            Vector2.left,
            0,
            playerLayer
        );
        
        return hit.collider != null;
    }
}
