using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public Text TxtHightScore;
    void Start()
    {
        TxtHightScore.text = PlayerPrefs.GetFloat("TextHightScore", 0).ToString("0.0");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
