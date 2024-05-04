using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private Text healthText;

    private void Start()
    {
        //playerHealth = GetComponent<Health>();
        //healthText = GetComponent<Text>();
    }
    void Update()
    {
        healthText.text = $"Health: {playerHealth.CurrentHealth}";
    }
}
