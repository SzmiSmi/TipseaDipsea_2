using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "r_handMeshNode" || collision.gameObject.name == "l_handMeshNode")
        {
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
    }
}
