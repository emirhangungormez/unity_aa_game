using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnaCember : MonoBehaviour
{
    public GameObject kucukCember;
    GameObject OyunYoneticisi;

    void Start()
    {
        OyunYoneticisi = GameObject.FindGameObjectWithTag("OyunYoneticisiTag");
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) //mouse'a týklandýðý an
        {
            kucukCemberOlustur();
        }
        
    }

    void kucukCemberOlustur()
    {
        Instantiate(kucukCember, transform.position, transform.rotation);
        OyunYoneticisi.GetComponent<OyunYoneticisi>().KucukCemberlerdeTextGosterme();
    }
}
