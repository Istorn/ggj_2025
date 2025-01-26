using UnityEngine;

public class spawnPlayer : MonoBehaviour
{
    public int numeroGiocatori;
    public Transform[] puntiDiSpawn;
    public GameObject prefabPlayer;
    GameObject istanzaPlayer;
    public Sprite[] visi;
    public Color[] coloriElmetti;
    void Start()
    {
        numeroGiocatori = 1;
    }

    public void met_AddPlayer()
    {
        if(numeroGiocatori<4)
        {
            numeroGiocatori++;
        }
    }
    public void met_RemovePlayer()
    {
        if(numeroGiocatori>1)
        {
            numeroGiocatori--;
        }    
    }
    // Start is called before the first frame update
    public void met_StartGame()
    {
        for (int i = 0; i < numeroGiocatori; i++)
        {
            istanzaPlayer=Instantiate(prefabPlayer, puntiDiSpawn[i].position, Quaternion.identity);
            istanzaPlayer.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().sprite=visi[i];
            istanzaPlayer.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().color=coloriElmetti[i];
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
