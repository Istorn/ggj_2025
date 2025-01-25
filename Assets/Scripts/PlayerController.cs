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
        //rb.velocity=new Vector2(orizzontale*speed, rb.velocity.y);
        if (rb.velocity.x<3f  && orizzontale>0) rb.AddForce(new Vector2(orizzontale*speed,0));
        if (rb.velocity.x>-3f  && orizzontale<0) rb.AddForce(new Vector2(orizzontale*speed,0));
        
        // rb.velocity.x>-0.1f)
        // rb.AddForce(new Vector2(orizzontale*speed,0));
    }
    public void Move(InputAction.CallbackContext context)
    {
        // Debug.Log(context);
         orizzontale=context.ReadValue<Vector2>().x;
        // if(context.performed)
        // {
        //     rb.AddForce(new Vector2(orizzontale*speed,0));
        // }
        
    }
    public void Jump(InputAction.CallbackContext context)
    {
        if(context.performed && grounded)
        {
            rb.velocity=new Vector2(rb.velocity.y,jumpPower);
        }
    }
    void OnCollisionEnter2D(Collision2D other) {
        
        // if (other.gameObject.tag == "ground") 
        // {
        //     grounded=true;
        // }
        if (other.gameObject.tag == "Player") 
        {
            Debug.Log("colpito!");
            // other.gameObject.GetComponent<Rigidbody2D>().AddForce(
            //     new Vector2(1000,8),ForceMode2D.Impulse);
            if (other.transform.position.x>this.transform.position.x) other.gameObject.GetComponent<Rigidbody2D>().AddForce(
                new Vector2(3,1),ForceMode2D.Impulse);
            if (other.transform.position.x<=this.transform.position.x) other.gameObject.GetComponent<Rigidbody2D>().AddForce(
                new Vector2(-3,1),ForceMode2D.Impulse);
        }
    }
    // void OnCollisionExit2D(Collision2D other) {
    //     if (other.gameObject.tag == "ground") 
    //     {
    //         grounded=false;
    //     }
    // }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "ground") 
        {
            grounded=true;
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "ground") 
        {
            grounded=false;
        }
    }
}
