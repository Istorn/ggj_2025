using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sound_bolla : MonoBehaviour
{
    public AudioSource bolla_AudioSource;
    public AudioClip bollaSfx_clip;

    public float pitchRange = 0.5f;          // Range del pitch (da -2 a +2)
    public float stepInterval = 0.5f;      // Intervallo tra i passi in secondi

    // Start is called before the first frame update
    void Start()
    {

    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "collider_bolla") 
        {
            Debug.Log("bollaaaa");
            if (bolla_AudioSource == null)
            {
                bolla_AudioSource = GetComponent<AudioSource>();
            }
                // bolla_AudioSource.pitch = Random.Range(-pitchRange, pitchRange); // Pitch casuale tra -2 e +2
                bolla_AudioSource.clip = bollaSfx_clip;
                bolla_AudioSource.loop = false;
                bolla_AudioSource.Stop();
                bolla_AudioSource.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}