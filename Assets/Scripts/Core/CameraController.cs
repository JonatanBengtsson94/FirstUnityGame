using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 targetPos = Vector3.zero;
    [SerializeField] private float ymin = 0.25f;
    [SerializeField] private float ymax = 3;
    private float speed = 0.25f;
    [SerializeField] private Transform player;
    [SerializeField] private float lookAheadDistance;
    private Vector3 velocity = Vector3.zero;

    private void Start()
    {
        targetPos = new Vector3(player.position.x, player.position.y, transform.position.z);
    }

    private void LateUpdate()
    {
        targetPos.y = Mathf.Clamp(player.position.y, ymin, ymax);
        targetPos.x = player.position.x + (lookAheadDistance * player.localScale.x);
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, speed);
    }
}
