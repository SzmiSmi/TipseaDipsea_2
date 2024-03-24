using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swim : MonoBehaviour
{
    public float speed = 5f;
    private Vector3 moveDirection;
    public Transform vrCamera;
    // Start is called before the first frame update
    void Start()
    {
        moveDirection = (vrCamera.position- transform.position).normalized;
        GetComponent<Rigidbody>().useGravity = false;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += moveDirection * speed * Time.deltaTime;

    }
}
