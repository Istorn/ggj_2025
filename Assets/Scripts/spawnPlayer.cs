using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnPlayer : MonoBehaviour
{
    public int numeroGiocatori;
    public Transform[] puntiDiSpawn;
    public GameObject prefabPlayer;
    GameObject istanzaPlayer;
    public Sprite[] visi;
    public Color[] coloriElmetti;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numeroGiocatori; i++)
        {
            istanzaPlayer=Instantiate(prefabPlayer, puntiDiSpawn[i].position, Quaternion.identity);
            istanzaPlayer.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().sprite=visi[i];
            istanzaPlayer.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().color=coloriElmetti[i];
        }
    }
}
