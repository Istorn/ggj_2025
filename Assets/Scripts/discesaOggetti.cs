using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class discesaOggetti : MonoBehaviour
{
    // Start is called before the first frame update
   public float minHeight; // Altezza limite
    private Rigidbody2D rb;
    public float timeToDestroy;
    public float slowFallSpeed = 2; 
    public float delay = 0.04f;  
    public bool fermato = false;
    void Start()
    {
        minHeight = Random.Range(1,8);

        // Assicuriamoci che l'oggetto abbia un Rigidbody2D
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("L'oggetto non ha un Rigidbody2D. Aggiungilo per far funzionare lo script.");
        }
        StartCoroutine(gestioneTempo());
        
        
    }

    void Update()
    {
        if (transform.position.y <= minHeight && fermato == false)
        {
            // Ferma il movimento verticale sotto l'altezza limite
             fermato = true;
            StartCoroutine(velocita());
        }
        
    }

    // void StopObject()
    // {
    //     // Imposta la posizione minima
    //     transform.position = new Vector3(transform.position.x, minHeight, transform.position.z);

    //     // Blocca il movimento lungo l'asse Y
    //     if (rb != null)
    //     {
    //         rb.velocity = new Vector2(rb.velocity.x, 0); // Blocca la velocità verticale
    //         rb.gravityScale = 0; // Disabilita la gravità per fermare completamente l'oggetto
    //     }
    // }
    
    IEnumerator gestioneTempo()
    {
        yield return new WaitForSeconds(timeToDestroy);
        Destroy(gameObject);
    }
    IEnumerator velocita()
    {
        rb.gravityScale = 0;
        // Modifica la velocità verticale per rallentare la caduta
        while (rb.velocity.y <= 0)
        {
            
            yield return new WaitForSeconds(delay);

            if(rb.velocity.y <= 0)
            {
                 rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y/slowFallSpeed);
            }
            else rb.velocity = new Vector2(rb.velocity.x,0);
            
            
        }
        
    }

    
}
