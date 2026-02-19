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
    private bool jumpRelease;

    public int interactingRange;

    public int damage = 5;
    public EnemyHealth current;
    public BossHealth current2;

    private float groundDisableTime = 0.1f;
    private float groundDisableCount = 0;
    WeaponSwitch weaponSwitch;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame

    private void Update()
    {
        Move();
        Jump();

        if (groundDisableCount > 0) 
        {
            groundDisableCount -= Time.deltaTime;
        }
    }
    public void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(horizontalInput, 0, verticalInput) * moveSpeed;
        move = transform.TransformDirection(move);

        Vector3 newVelocity = new Vector3(move.x, rigidBody.velocity.y, move.z);
        rigidBody.velocity = newVelocity;
    }
    public void Jump()
    { 
        if (Input.GetKeyDown(KeyCode.Space) && jumpRelease)
        {
            if (isGrounded) 
            {
                FirstJump();
            }
            else if (canDoubleJump) 
            {
                SecondJump();
            }
        }
        if (Input.GetKeyUp(KeyCode.Space)) 
        {
            jumpRelease = true;
        }

    }
    void FirstJump() 
    {
        rigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        canDoubleJump = true;
        isGrounded = false;
    }
    void SecondJump() 
    {
        rigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        canDoubleJump = false;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") && groundDisableCount <= 0) 
        { 
            isGrounded = true;
        }
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            current = other.gameObject.GetComponent<EnemyHealth>();
        }
        if (other.gameObject.CompareTag("Boss"))
        {
            current2 = other.gameObject.GetComponent<BossHealth>();
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            current = null;
        }
    }
}
