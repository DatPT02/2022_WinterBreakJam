using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private CharacterController myCharacterController;
    [SerializeField] private float moveSpeed = 15f;
    [SerializeField] private float gravity = -9.81f;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckDistance = 0.5f;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float jumpHeight = 5f;

    private float xMovement;
    private float zMovement;
    private Vector3 moveDir;
    private Vector3 velocity;
    private bool isOnGround = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isOnGround = Physics.CheckSphere(groundCheck.position, groundCheckDistance, groundMask);

        if(isOnGround && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        xMovement = Input.GetAxis("Horizontal");
        zMovement = Input.GetAxis("Vertical");

        moveDir = transform.right * xMovement + transform.forward * zMovement; 

        myCharacterController.Move(moveDir * moveSpeed * Time.deltaTime);

        // if(Input.GetButtonDown("Jump") && isOnGround)
        // {
        //     velocity.y = Mathf.Sqrt(jumpHeight * (-2f) * gravity);
        // }

        velocity.y += (gravity * Time.deltaTime);
        myCharacterController.Move(velocity * Time.deltaTime);
    }
}
