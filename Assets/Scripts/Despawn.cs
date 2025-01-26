using UnityEngine;

public class Despawn : MonoBehaviour
{
    public GameplayManager gameplayManager;
    public AudioSource music_AudioSource; 
    public AudioClip gameOver_Clip;
    void OnTriggerEnter2D(Collider2D collision)
     {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameplayManager.met_GameOver();

            music_AudioSource.Stop();
            music_AudioSource.clip = gameOver_Clip;
            music_AudioSource.Play();

            Debug.Log("Game Over");
        }
        else if (collision.gameObject.CompareTag("bonus"))
        {
            Destroy(collision.gameObject);
            Debug.Log("Bonus distrutto");
        }
     }
     
}
