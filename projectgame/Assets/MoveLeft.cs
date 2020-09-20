using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{   

    public float speed = 10;
    //Defult speed of oject
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position += Vector3.left * speed * Time.deltaTime;
        //about move position
    }
}
