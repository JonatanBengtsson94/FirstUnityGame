using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 targetPos = Vector3.zero;
    private float ymin = 0.25f;
    private float speed = 0.25f;
    [SerializeField] private Transform player;
    [SerializeField] private float lookAheadDistance;
    private Vector3 velocity = Vector3.zero;

    private void Awake()
    {
        targetPos = new Vector3(player.position.x, player.position.y, transform.position.z);
    }

    private void LateUpdate()
    {
        if (player.position.y > ymin)
        {
            targetPos.y = player.position.y;
        } else 
        {
            targetPos.y = ymin;    
        }
        targetPos.x = player.position.x + (lookAheadDistance * player.localScale.x);
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, speed);
    }
}
