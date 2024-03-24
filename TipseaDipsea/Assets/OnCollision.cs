using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollision : MonoBehaviour
{
    private AudioSource audioSource;
    private AudioClip audioClip;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void SetAudioSource(AudioSource newAudioSource)
    {
        audioSource = newAudioSource;
    }
    public void SetAudioClip(AudioClip newAudioClip)
    {
        audioClip = newAudioClip;
    }
    private void OnTriggerEnter(Collider collision)
    {

        Debug.Log("fish slapped by "+collision.gameObject.name);
        audioSource.PlayOneShot(audioClip);
        Destroy(gameObject);
        
    }
    // Update is called once per frame
    void Update()
    {
    }
}
