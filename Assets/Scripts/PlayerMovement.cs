using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D playerBody;
    public float movementSpeed = 5f;
    public bool facingRight = true;
    // Start is called before the first frame update
    void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Move(float horizontalInput)
    {
        if (horizontalInput != 0) 
        { 
            CheckFacingDirection(horizontalInput);
            float horizontalvelocity = horizontalInput * movementSpeed;
            playerBody.velocity = new Vector2 (horizontalvelocity, playerBody.velocity.y);
        }
    }
    private void CheckFacingDirection(float horizontalInput)
    {
        if(facingRight && horizontalInput < 0f)
        {
            Flip();
        }
        else if (!facingRight && horizontalInput > 0f)
        {
            Flip();
        }
    }
    private void Flip()
    {
        var playerScale = transform.localScale;
        transform.localScale = new Vector3(playerScale.x * -1, playerScale.y, playerScale.z);
        facingRight = !facingRight;
    }
}
