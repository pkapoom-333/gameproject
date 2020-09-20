using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecycleRoad : MonoBehaviour
{
    public Transform StartpointRoad;
    public Transform EndpointRoad;
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < EndpointRoad.position.x)
        {
            float gap = EndpointRoad.position.x - transform.position.x;
            transform.position = new Vector3(StartpointRoad.position.x, transform.position.y, transform.position.z);
        }
    }
}
