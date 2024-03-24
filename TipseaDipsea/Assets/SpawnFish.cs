using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFish : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject fishPrefab;
    public GameObject target1;
    public GameObject target2;
    public GameObject target3;
    public GameObject target4;
    private GameObject thisTarget;
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
        fishDirection = target1.transform.position - transform.position;
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
            int targetNo = Random.Range(0,4);
            if(targetNo == 0) thisTarget = target1;
            else if(targetNo == 1) thisTarget = target2;
            else if(targetNo == 2) thisTarget = target3;
            else thisTarget = target4;
            fishDirection = thisTarget.transform.position - transform.position;
            lookRotation = Quaternion.LookRotation(fishDirection);

            GameObject fish = Instantiate(fishPrefab, transform.position, lookRotation);
            Swim swimControl = fish.GetComponent<Swim>();
            OnCollision collisionControl = fish.GetComponent<OnCollision>();
            if(swimControl!= null) 
            {
                swimControl.SetTarget(thisTarget);
                swimControl.SetBpm(bpm);
                collisionControl.SetAudioSource(positiveSound);
                collisionControl.SetAudioClip(positiveSoundClip);
            }
            timer = 0;
        }
        
    }
}
