using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public float jumpPower;
    float orizzontale;
    public bool grounded;
    
    private void FixedUpdate() 
    {
        rb.velocity=new Vector2(orizzontale*speed, rb.velocity.y);
    }
    public void Move(InputAction.CallbackContext context)
    {
        Debug.Log(context);
        orizzontale=context.ReadValue<Vector2>().x;
    }
    public void Jump(InputAction.CallbackContext context)
    {
        if(context.performed && grounded)
        {
            rb.velocity=new Vector2(rb.velocity.y,jumpPower);
        }
    }
    void OnCollisionEnter2D(Collision2D other) {
        
        if (other.gameObject.tag == "ground") 
        {
            grounded=true;
        }
    }
    void OnCollisionExit2D(Collision2D other) {
        if (other.gameObject.tag == "ground") 
        {
            grounded=false;
        }
    }
}
