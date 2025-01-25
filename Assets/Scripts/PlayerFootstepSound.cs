using UnityEngine;

public class PlayerFootstepSound : MonoBehaviour
{
    public AudioSource footstepAudioSource; // AudioSource per il suono dei passi
    public AudioClip footstepClip;          // Clip audio del passo
    public float pitchRange = 2f;          // Range del pitch (da -2 a +2)
    public float stepInterval = 0.5f;      // Intervallo tra i passi in secondi

    private bool isWalking = false;

    void Start()
    {
        if (footstepAudioSource == null)
        {
            footstepAudioSource = GetComponent<AudioSource>();
        }

        footstepAudioSource.clip = footstepClip;
        footstepAudioSource.loop = false;
    }

    void Update()
    {
        // Controlla se il giocatore sta camminando (puoi personalizzare il controllo con il tuo input)
        isWalking = Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0;

        if (isWalking && !IsInvoking("PlayFootstepSound"))
        {
            InvokeRepeating("PlayFootstepSound", 0f, stepInterval);
        }
        else if (!isWalking)
        {
            CancelInvoke("PlayFootstepSound");
        }
    }

    void PlayFootstepSound()
    {
        if (footstepAudioSource != null && footstepClip != null)
        {
            footstepAudioSource.pitch = Random.Range(-pitchRange, pitchRange); // Pitch casuale tra -2 e +2
            footstepAudioSource.Play();
        }
    }
}
