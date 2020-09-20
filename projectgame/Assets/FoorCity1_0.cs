using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoorCity1_0 : MonoBehaviour
{
    public float bgSpeed;
    float bgPositionX;
    float bg1PositionX;
    void Start()
    {
        bgPositionX = transform.position.x;
        bg1PositionX = GameObject.Find("BlackgroundCity1_6").transform.position.x;

    }


    void Update()
    {
        transform.position = new Vector3(transform.position.x + bgSpeed, transform.position.y, transform.position.z);
       if (transform.position.x < (bg1PositionX *-1f))
        {
            transform.position = new Vector3(bg1PositionX, transform.position.y, transform.position.z);
        }

    }
}
