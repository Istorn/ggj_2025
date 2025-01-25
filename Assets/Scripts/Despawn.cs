using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     void OnTriggerEnter2D(UnityEngine.Collider2D collision)
     {
        if (collision.gameObject.CompareTag("Player")){
            //game over
        }
        else if (collision.gameObject.CompareTag("bonus")){
            Destroy(collision.gameObject);
            Debug.Log("test");
        }
     }
     
}
