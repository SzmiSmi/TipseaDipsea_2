using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFish : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject fishPrefab;
    
    void Start()
    {
        Instantiate(fishPrefab, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
