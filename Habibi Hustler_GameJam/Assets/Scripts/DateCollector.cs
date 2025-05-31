using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DateCollector : MonoBehaviour
{
    public TextMeshProUGUI dateCounterText;
    private int dateCount = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("date"))
        {
            dateCount++;
            UpdateDateCounterUI();

            
        }
    }

    private void UpdateDateCounterUI()
    {
        if (dateCounterText != null)
        {
            dateCounterText.text = "Dates Collected: " + dateCount;
        }
    }
}
