using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class randomizzatoreAttrezzi : MonoBehaviour
{
    public Sprite[] spriteAttrezzi;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < spriteAttrezzi.Length; i++)
        {
            this.GetComponent<SpriteRenderer>().sprite = spriteAttrezzi[Random.Range(0,spriteAttrezzi.Length)];
        }
    }
}
