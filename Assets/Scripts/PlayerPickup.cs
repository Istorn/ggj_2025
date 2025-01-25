using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    public PointsManager pointsManager;
    Rigidbody2D rb;
    public int massAdd;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if(CompareTag("bonus"))
        {
            pointsManager.met_AggiungiPunti(50);
            rb.mass += massAdd;
            Destroy(other.gameObject);
        }
    }
}
