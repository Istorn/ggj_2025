using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    public PointsManager pointsManager;
    Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag =="bonus")
        {
            float punteggio = other.gameObject.GetComponent<BonusPoints>().actualPoints;
            pointsManager.met_AggiungiPunti(Mathf.FloorToInt(punteggio*100));

            rb.mass += punteggio/5;
            rb.gameObject.GetComponent<PlayerController>().speed += 5*punteggio;
            rb.gameObject.GetComponent<Transform>().localScale += new UnityEngine.Vector3(1f*punteggio/50, 1f*punteggio/50, 1f);

            Destroy(other.gameObject);
        }
    }
}
