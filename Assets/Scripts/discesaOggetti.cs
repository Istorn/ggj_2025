using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class discesaOggetti : MonoBehaviour
{
    // Start is called before the first frame update
   public float minHeight = -1; // Altezza limite
    private Rigidbody2D rb;
    public float timeToDestroy;
    void Start()
    {
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
        if (transform.position.y <= minHeight)
        {
            // Ferma il movimento verticale sotto l'altezza limite
            StopObject();
        }
        
    }

    void StopObject()
    {
        // Imposta la posizione minima
        transform.position = new Vector3(transform.position.x, minHeight, transform.position.z);

        // Blocca il movimento lungo l'asse Y
        if (rb != null)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0); // Blocca la velocità verticale
            rb.gravityScale = 0; // Disabilita la gravità per fermare completamente l'oggetto
        }
    }
    
    IEnumerator gestioneTempo()
    {
        yield return new WaitForSeconds(timeToDestroy);
        Destroy(gameObject);
    }
}
