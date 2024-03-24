using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFish : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject fishPrefab;
    public GameObject target;
    private Vector3 fishDirection;
    private Quaternion lookRotation;

    private float timer = 0.0f;
    private float spawnRate;
    public float bpm = 105.0f;

    public AudioSource positiveSound;
    public AudioClip positiveSoundClip;
    
    void Start()
    {
        spawnRate = 4*60/bpm;
        fishDirection = target.transform.position - transform.position;
        lookRotation = Quaternion.LookRotation(fishDirection);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timer<spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            GameObject fish = Instantiate(fishPrefab, transform.position, lookRotation);
            Swim swimControl = fish.GetComponent<Swim>();
            if(swimControl!= null) 
            {
                swimControl.SetTarget(target);
                swimControl.SetBpm(bpm);
                swimControl.SetAudioSource(positiveSound);
                swimControl.SetAudioClip(positiveSoundClip);
            }
            timer = 0;
        }
        
    }
}
