using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recycle : MonoBehaviour
{
    public Transform Startpoint;
    public Transform Endpoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < Endpoint.position.x)
        {
            float gap = Endpoint.position.x - transform.position.x;
            transform.position = new Vector3(Startpoint.position.x, transform.position.y, transform.position.z);
        }
        
    }
}
