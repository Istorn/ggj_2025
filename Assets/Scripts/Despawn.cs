using UnityEngine;

public class Despawn : MonoBehaviour
{
    public GameplayManager gameplayManager;
    void OnTriggerEnter2D(Collider2D collision)
     {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameplayManager.met_GameOver();
            Debug.Log("Game Over");
        }
        else if (collision.gameObject.CompareTag("bonus"))
        {
            Destroy(collision.gameObject);
            Debug.Log("Bonus distrutto");
        }
     }
     
}
