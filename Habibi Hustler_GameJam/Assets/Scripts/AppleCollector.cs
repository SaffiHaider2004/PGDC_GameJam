using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AppleCollector : MonoBehaviour
{
    public TextMeshProUGUI AppleCounterText;
    private int appleCount = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("apple"))
        {
            appleCount++;
            UpdateAppleCounterUI();

            
        }
    }

    private void UpdateAppleCounterUI()
    {
        if (AppleCounterText != null)
        {
            AppleCounterText.text = "Apples Collected: " + appleCount;
        }
    }
}
