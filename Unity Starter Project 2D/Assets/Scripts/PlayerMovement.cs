using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// RequireComponent adds the specified component to an object when the script is added
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
// Serializing a private field allows you to change the field in the editor
[System.Serializable]
public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float moveSpeed;

    private Vector2 movement;
    private bool facingRight = true;
    private float moveAngle;
    private float dTime;
    private float moveSpeedScale = 25;

    // Start is called before the first frame update
    void Start()
    {
        if(rb2d == null)
        {
            rb2d = GetComponent<Rigidbody2D>();
        }
        rb2d.gravityScale = 0;

    }

    // Update is called roughly as many times as possible
    void FixedUpdate()
    {
        Move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), Time.fixedDeltaTime);
    }

    void Move(float xIn, float yIn, float dTime)
    {
        // get the xIn and yIn values and get a move angle out of it
        // move the player in the move angle at move speed

        moveAngle = Mathf.Atan2(Mathf.Abs(yIn), Mathf.Abs(xIn));

        movement.x = xIn * dTime * moveSpeed * moveSpeedScale * Mathf.Cos(moveAngle);
        movement.y = yIn * dTime * moveSpeed * moveSpeedScale * Mathf.Sin(moveAngle);

        rb2d.velocity = movement;

        // flip the player if neccessary
        if (facingRight && movement.x < 0) Flip();
        else if (!facingRight && movement.x > 0) Flip();
    }

    void Flip()
    {
        transform.Rotate(0, 180, 0);
        facingRight = !facingRight;
    }
}
