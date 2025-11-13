using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 500f;
    private Rigidbody rigidBody;

    private bool canDoubleJump;
    private bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(horizontalInput, 0, verticalInput) * moveSpeed;
        move = transform.TransformDirection(move);

        Vector3 newVelocity = new Vector3(move.x, rigidBody.velocity.y, move.z);
        rigidBody.velocity = newVelocity;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded) 
            {
                rigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                canDoubleJump = true;
                isGrounded = false;
            }
            else if (canDoubleJump) 
            {
                rigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                canDoubleJump = false;
            }
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) 
        {
            isGrounded = true;
        }
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) 
        {
            isGrounded = false;
        }
    }
}
