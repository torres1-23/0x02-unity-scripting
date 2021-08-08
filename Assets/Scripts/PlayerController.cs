using UnityEngine;

/// <summary>Handles player controller class</summary>
public class PlayerController : MonoBehaviour
{
    public float speed = 500;
    private int score = 0;
    Rigidbody body;

    // Start is called before the first frame update
    /// <summary>Gets rigidbody component from player ball</summary>
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    /// <summary>Updates velocity of player rigidbody</summary>
    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput);
        body.velocity = movement * speed * Time.deltaTime;
    }

    /// <summary>Updates score value when player collides with coin, destroys coin</summary>
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pickup")
        {
            score++;
            Debug.Log($"Score: {score}");
            Destroy(other.gameObject);
        }
    }
}
