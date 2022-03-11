using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerCube : MonoBehaviour
{
    public float speed = 100f;
    public float jumpForce = 10;
    public float gravityModifer;
    private Rigidbody playerRb;
    private bool isOnGround = false;

    private int limitX = 40;
    private int limitZ = 40;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>(); 
        // Gravity change   
        Physics.gravity *= gravityModifer;    
    }

    void Update()
    {
        // Player movement horizontally or vertically
        movePlayer();
        // Player limitation on 4 axes
        playerMovementRestriction();

        // Player limit for one jump
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            isOnGround = false;
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
    
    private void movePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        playerRb.AddForce(Vector3.forward * speed * verticalInput);
        playerRb.AddForce(Vector3.right * speed * horizontalInput);
    }

    private void playerMovementRestriction()
    {
        if(transform.position.x > limitX)
        {
            transform.position = new Vector3(limitX, transform.position.y, transform.position.z);
            playerRb.velocity = Vector3.zero;
        }
        if(transform.position.x < -limitX)
        {
            transform.position = new Vector3(-limitX, transform.position.y, transform.position.z);
            playerRb.velocity = Vector3.zero;
        }
        if(transform.position.z > limitZ)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, limitZ);
            playerRb.velocity = Vector3.zero;
        }
        if(transform.position.z < -limitZ)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -limitZ);
            playerRb.velocity = Vector3.zero;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }
}
