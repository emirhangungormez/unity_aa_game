using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KucukCember : MonoBehaviour
{
    Rigidbody2D fizik;
    public float hiz;
    bool hareketKontrol = false;
    GameObject oyunYoneticisi;

    void Start()
    {
        fizik = GetComponent<Rigidbody2D>();
        oyunYoneticisi = GameObject.FindGameObjectWithTag("OyunYoneticisiTag");
    }


    void FixedUpdate()
    {
        if (!hareketKontrol)
        {
            fizik.MovePosition(fizik.position + Vector2.up * hiz * Time.deltaTime);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "DonenCemberTag")
        {
            transform.SetParent(col.transform); //çarptýðý nesnenin alt nesnesi olacak
            hareketKontrol = true;
        }

        if(col.tag == "KucukCemberTag")
        {
            oyunYoneticisi.GetComponent<OyunYoneticisi>().OyunBitti(); //script'te ulaþýyoruz.
        }
    }
}
