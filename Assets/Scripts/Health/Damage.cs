using UnityEngine;

public class Damage: MonoBehaviour
{
    private enum Tag
    {
        Player,
        Enemy
    }
    [SerializeField] private int damage;
    [SerializeField] private Tag hostileTag;
    private string hostileTagString;

    private void Awake()
    {
        hostileTagString = (hostileTag == Tag.Player) ? "Player" : "Enemy";
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(hostileTagString))
        {
            collision.GetComponent<Health>().TakeDamage(damage);
        }
    }
}
