using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    bool isAlive=true;
    [SerializeField]
    public float forwardSpeed = 8f;
    float horizontalSpeed = 10f;
    Rigidbody rb;
    float HorizontalInput;

    public float speedIncreasePerPoint = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        rb=gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isAlive)
            return;
        Vector3 forwardMove = transform.forward * forwardSpeed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * HorizontalInput * horizontalSpeed * Time.fixedDeltaTime;
        rb.MovePosition(transform.position + forwardMove + horizontalMove);
        
    }

    private void Update()
    {
        HorizontalInput = Input.GetAxis("Horizontal");

        if (transform.position.y < -5)
        {
            Die();
        }
    }

    public void Die()
    {
        isAlive = false;
        // Restart the game
        Invoke("Restart", 1);
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
