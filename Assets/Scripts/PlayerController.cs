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

    public AudioSource jumpAudioSource;
    public AudioClip jumpAudioClip;
    
    private void FixedUpdate() 
    {
        //rb.velocity=new Vector2(orizzontale*speed, rb.velocity.y);
        if (rb.velocity.x<3f  && orizzontale>0) rb.AddForce(new Vector2(orizzontale*speed,0));
        if (rb.velocity.x>-3f  && orizzontale<0) rb.AddForce(new Vector2(orizzontale*speed,0));
        
        // rb.velocity.x>-0.1f)
        // rb.AddForce(new Vector2(orizzontale*speed,0));
        if (rb.velocity.y<-1)
        {
            Debug.Log("cadoooooo");
            rb.AddForce(new Vector2(0,-10));
        }
    }
    public void Move(InputAction.CallbackContext context)
    {
         orizzontale=context.ReadValue<Vector2>().x;
    }
    public void Jump(InputAction.CallbackContext context)
    {
        if(context.performed && grounded)
        {
            rb.velocity=new Vector2(rb.velocity.x,jumpPower);
            jumpAudioSource.clip = jumpAudioClip;
            jumpAudioSource.Stop();
            jumpAudioSource.Play();
        }
    }
    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Player") 
        {
            Debug.Log("colpito!");
            // other.gameObject.GetComponent<Rigidbody2D>().AddForce(
            //     new Vector2(1000,8),ForceMode2D.Impulse);
            if (other.transform.position.x>this.transform.position.x) other.gameObject.GetComponent<Rigidbody2D>().AddForce(
                new Vector2(5,1),ForceMode2D.Impulse);
            if (other.transform.position.x<=this.transform.position.x) other.gameObject.GetComponent<Rigidbody2D>().AddForce(
                new Vector2(-5,1),ForceMode2D.Impulse);
        }
    }

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
