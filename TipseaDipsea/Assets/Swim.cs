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

    public Color[] colors = new Color[5];
    private Material fishMaterial;



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
   


    // Start is called before the first frame update
    void Start()
    {
        colors[0] = Color.red;
        colors[1] = Color.green;
        colors[2] = Color.blue;
        colors[3] = Color.yellow;
        colors[4] = Color.black;
        fishMaterial = GetComponent<Renderer>().material;

        ChangeColor();


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
    void ChangeColor()
    {
        Color newColor = colors[Random.Range(0, colors.Length)]; // Pick a random color
        fishMaterial.color = newColor; // Set the fish's color to the new random color
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
