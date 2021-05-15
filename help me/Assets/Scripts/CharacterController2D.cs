using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{

    public float MovementSpeed = 1f;
    public float JumpForce = 1f;

    public bool isgrounded;

    public bool doubleJump;

    public Rigidbody2D rb2d; 
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    
    void FixedUpdate()
    {
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;

        
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && isgrounded == true)
        {
            doubleJump = true;
            rb2d.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            

            
        }

        if (doubleJump == true && Input.GetButtonDown("Jump") && isgrounded == false)
            {
                rb2d.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
                doubleJump = false;
            }
    }
    

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ground")
        {
            isgrounded = true;
        }
       
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Ground")
        {
            isgrounded = false;
        }
    }
}
