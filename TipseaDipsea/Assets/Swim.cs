using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swim : MonoBehaviour
{
    //VARIABLES:
    private float speed;    //based on time required to traverse 50 units.
    private Vector3 moveDirection;
    private GameObject target;

    private float bpm = 120.0f;

    //Used to destroy fish after it passes player
    private float deadZone = -25f;

    
    private Material fishMaterial;

    public Color fishColor;


    //SETTERS: 
    //Set variables to scene items
    public void SetTarget(GameObject newTarget)
    {
        target = newTarget;
    }
    public void SetBpm(float newBpm)
    {
        bpm = newBpm;
    }
    public void SetColor(Color newColor)
    {
        fishColor = newColor;
    }
   


    // Start is called before the first frame update
    void Start()
    {
        
        fishMaterial = GetComponent<MeshRenderer>().material;
        fishMaterial.color = fishColor;

        if(target!= null)
        {
            moveDirection = (target.transform.position - transform.position).normalized;
        }
        else{
            moveDirection = new Vector3(0.0f,1.0f,0.0f);
        }
        GetComponent<Rigidbody>().useGravity = false;
        speed = 50*bpm/240;
        

    }


    // Update is called once per frame
    void Update()
    {
        if(target!= null)
        {
            transform.position += moveDirection * speed * Time.deltaTime;
        }
        
        if(transform.position.z<deadZone){
            Destroy(gameObject);
        }
    }
}
