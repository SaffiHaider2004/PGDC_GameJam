using UnityEngine;

public class PlayerCollect : MonoBehaviour
{
    public int coinCount = 0;
    public int gemCount = 0;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("apple"))
        {
            coinCount++;
            Destroy(other.gameObject);
            Debug.Log("Collected apple: " + coinCount);
        }
        else if (other.CompareTag("date"))
        {
            gemCount++;
            Destroy(other.gameObject);
            Debug.Log("Collected date: " + gemCount);
        }
    }
}
