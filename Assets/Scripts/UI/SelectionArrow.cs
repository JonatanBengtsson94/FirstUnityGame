using System;
using UnityEngine;
using UnityEngine.UI;

public class SelectionArrow : MonoBehaviour
{
    private int currentPosition;
    private RectTransform rect;
    [SerializeField] private RectTransform[] options;
    private float previousInput;

    void Awake()
    {
        rect = GetComponent<RectTransform>();
    }

    void Update()
    {
        int verticalInput = Math.Sign(Input.GetAxis("Vertical"));
        if (verticalInput != previousInput)
        {
            if (verticalInput > 0) 
            {
                ChangePosition(-1);
            }
            if (verticalInput < 0)
            {
                ChangePosition(1);
            }
        }
        previousInput = verticalInput;

        if (Input.GetButtonDown("Fire1")) 
        {
            Interact();
        }
    }

    private void ChangePosition(int change)
    {
        currentPosition += change;
        if (currentPosition < 0)
        {
            currentPosition = options.Length -1;
        }
        if (currentPosition > options.Length -1)
        {
            currentPosition = 0;
        }

        rect.position = new Vector3(rect.position.x, options[currentPosition].position.y, 0); 
    }

    private void Interact()
    {
        options[currentPosition].GetComponent<Button>().onClick.Invoke();
    }
}
