using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnObject : MonoBehaviour
{
     SpriteRenderer sr;
     public GameObject bonus;
     public float durataAttesa;
     public int i; 
     public int iterationCount;
     public float posXMin;
     public float posXMax;
     public float posYMin;
     public float posYMax;

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
             yield return new WaitForSeconds(durataAttesa);
             sr = GetComponent<SpriteRenderer> ();
             Invoke("SpawnNext", 2f);
             }
        }
     
     void SpawnNext()
    {
      
        GameObject FallingEggs = Instantiate(bonus);
        FallingEggs.transform.position = new Vector3(Random.Range(posXMin, posXMax), posYMin, posYMax);
    }
    
}
