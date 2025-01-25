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

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag =="bonus")
        {
            pointsManager.met_AggiungiPunti(50);
            rb.mass += massAdd;
            Destroy(other.gameObject);
        }
    }
}
