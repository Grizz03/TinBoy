using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 4f;
    public float jumpForce = 10f;
    public float gravityScale = 5f;

    public CharacterController CharController;
    private Vector3 moveDirection;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float yStore = moveDirection.y;

        moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        moveDirection = moveDirection * moveSpeed;
        moveDirection.y = yStore;

        if (Input.GetButtonDown("Jump"))
        {
            moveDirection.y = jumpForce;
        }

        //added gravity to jump
        moveDirection.y += Physics.gravity.y * Time.deltaTime * gravityScale;

        // transform.position = transform.position + moveDirection * Time.deltaTime * moveSpeed;

        CharController.Move(moveDirection * Time.deltaTime);
    }
}
