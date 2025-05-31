using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float forwardSpeed = 5f;
    public float laneDistance = 3f;
    public float sideMoveSpeed = 10f;
    public float speedIncreaseRate = 0.5f;
    public float timeToIncreaseSpeed = 5f;

    private int currentLane = 1;
    private float speedTimer = 0f;
    private Animator anim;
    private bool isDead = false;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        anim.SetBool("isRunning", true);
    }

    void Update()
    {
        if (isDead) return;

        // Forward movement
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);

        // Speed increase
        speedTimer += Time.deltaTime;
        if (speedTimer >= timeToIncreaseSpeed)
        {
            forwardSpeed += speedIncreaseRate;
            speedTimer = 0f;
        }

        // Lane switching
        if (Input.GetKeyDown(KeyCode.LeftArrow) && currentLane > 0)
            currentLane--;
        else if (Input.GetKeyDown(KeyCode.RightArrow) && currentLane < 2)
            currentLane++;

        Vector3 targetPosition = new Vector3((currentLane - 1) * laneDistance, transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * sideMoveSpeed);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;
        anim.SetTrigger("Die");

        // Optional: stop game logic, show Game Over screen after delay
        Debug.Log("Player Died!");
    }
}
