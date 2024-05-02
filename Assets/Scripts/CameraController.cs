using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 targetPos = Vector3.zero;
    private float ymin = 0.25f;
    [SerializeField] private float speed;
    [SerializeField] private Transform player;
    [SerializeField] private float lookAheadDistance;

    private void Awake()
    {
        targetPos = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
    }
    private void Update()
    {
        if (player.position.y > ymin)
        {
            targetPos.y = player.position.y;
        } else 
        {
            targetPos.y = ymin;    
        }
        targetPos.x = player.position.x + (lookAheadDistance * player.localScale.x);
        transform.position = Vector3.Lerp(transform.position, targetPos, speed * Time.deltaTime);
    }

}
