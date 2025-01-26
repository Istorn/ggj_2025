using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class suonoSbarra : MonoBehaviour
{
    public AudioSource sbarraAudioSource;
    public AudioClip sbarraClip;
    public bool suonoAbilitato=true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("rotazione bridg"+GetComponent<Rigidbody2D>().angularVelocity);
        if (suonoAbilitato)
        {
            if (GetComponent<Rigidbody2D>().angularVelocity>30 || GetComponent<Rigidbody2D>().angularVelocity<-30)
            {
                sbarraAudioSource.clip = sbarraClip;
                sbarraAudioSource.Stop();
                sbarraAudioSource.Play();
                suonoAbilitato=false;
                Invoke("abilitaSuono",2.0f);
            }
        }
        
    }
    void abilitaSuono()
    {
        suonoAbilitato=true;
    }
}
