using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    public AudioSource bonusAudioSource;
    public AudioClip bonusAudioClip;
    public PointsManager pointsManager;
    Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pointsManager = FindObjectOfType<PointsManager>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag =="bonus")
        {
            float punteggio = other.gameObject.GetComponent<BonusPoints>().actualPoints;
            pointsManager.met_AggiungiPunti(Mathf.FloorToInt(punteggio*100));

            rb.mass += punteggio/5;
            rb.gameObject.GetComponent<PlayerController>().speed += 5*punteggio;
            rb.gameObject.GetComponent<Transform>().localScale += new Vector3(1f*punteggio/50, 1f*punteggio/50, 1f);

            Destroy(other.gameObject);

            bonusAudioSource.clip = bonusAudioClip;
            bonusAudioSource.Stop();
            bonusAudioSource.Play();
        }
    }
}
