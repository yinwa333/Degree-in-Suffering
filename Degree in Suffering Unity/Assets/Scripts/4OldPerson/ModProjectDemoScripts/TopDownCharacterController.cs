using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCharacterController : MonoBehaviour
{
    //Speed of character movement. Set this in the inspector.
    public float speed;

    //Assigning a variable where we'll store the Rigidbody2D component.
    private Rigidbody2D rb;

    //Variable where we will store the current movement value of our character.
    private Vector2 moveVelocity;

    // Start is called before the first frame update
    void Start()
    {
        //Sets our variable 'rb' to the Rigidbody2D component on the game object where this script is attached.
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //moveInput is assigning a value to our current direction of movement. Each axis ranges from -1 to 1 depending on the direction.
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        //The below version of moveInput uses GetAxisRaw, which will result in your character stopping more exactly when the arrow key is no longer pressed, rather than decelerating. 
        //Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        //moveVelocity combines our specified direction value and multiplies by our speed value.
        moveVelocity = moveInput.normalized * speed;
    }

    private void FixedUpdate()
    {
        //This is the line of code that actually moves our character.
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
     
    }
}
