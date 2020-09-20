using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Default"))
        {
            this.gameObject.SetActive(false);
            //เมื่อเจอกับตัวละครจะลบ Oject นั้นๆที่โดน
        }
    }
 
}
