using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private Text healthText;

    void Update()
    {
        healthText.text = $"Health: {playerHealth.CurrentHealth}";
    }
}
