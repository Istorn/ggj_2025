using System.Collections;
using UnityEngine;

public class spawnObject : MonoBehaviour
{
    // SpriteRenderer sr;
    public GameObject bonus;
    public float spawnStartDelay;
    public float spawnDelay;
    // public int i;
    // public int iterationCount;
    public float posXMin;
    public float posXMax;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(gestioneTempo());
    }

    // Update is called once per frame
    void Update()
    {

    }
    //void Awake()
    // {

    //   Invoke("SpawnNext", 1f);
    //}


    // IEnumerator gestioneTempo()
    // {
    //    for(int i = 0; i < iterationCount; i++){
    //   yield return new WaitForSeconds(durataAttesa);
    //  sr = GetComponent<SpriteRenderer> ();
    // Invoke("SpawnNext", 2f);
    // }
    //}

    IEnumerator gestioneTempo()
    {
        while (gameObject.activeSelf)
        {
            yield return new WaitForSeconds(spawnDelay);
            // sr = GetComponent<SpriteRenderer>();
            Invoke("SpawnNext", spawnStartDelay);
        }
    }

    void SpawnNext()
    {
        GameObject FallingEggs = Instantiate(bonus, new Vector3(Random.Range(posXMin, posXMax), 7f, 0f), Quaternion.identity);
        // FallingEggs.transform.position = new Vector3(Random.Range(posXMin, posXMax), posYMin, posYMax);
    }
}
