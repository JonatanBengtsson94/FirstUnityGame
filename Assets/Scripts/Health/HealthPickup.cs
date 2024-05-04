using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private int healthValue;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Health>().Heal(50);
            gameObject.SetActive(false);
        }
    }
}
