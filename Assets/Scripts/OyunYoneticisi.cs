using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OyunYoneticisi : MonoBehaviour
{
    GameObject donenCember;
    GameObject anaCember;
    public Animator animator;
    public Text donenCemberLevel;
    public Text bir;
    public Text iki;
    public Text uc;
    public int kacTaneKucukCemberOlsun;
    bool kontrol = true;

    void Start()
    {
        PlayerPrefs.SetInt("kayit", int.Parse(SceneManager.GetActiveScene().name));
        //kayýt sistemi (teefon hafýzasýna kaydeder)

        donenCember = GameObject.FindGameObjectWithTag("DonenCemberTag");
        anaCember = GameObject.FindGameObjectWithTag("AnaCemberTag");
        donenCemberLevel.text = SceneManager.GetActiveScene().name;

        if(kacTaneKucukCemberOlsun < 2)
        {
            bir.text = kacTaneKucukCemberOlsun + "";
        }
        else if(kacTaneKucukCemberOlsun < 3)
        {
            bir.text = kacTaneKucukCemberOlsun + "";
            iki.text = (kacTaneKucukCemberOlsun -1 ) + "";
        }
        else
        {
            bir.text = kacTaneKucukCemberOlsun + "";
            iki.text = (kacTaneKucukCemberOlsun - 1) + "";
            uc.text = (kacTaneKucukCemberOlsun - 2) + "";
        }
    }
    
    public void KucukCemberlerdeTextGosterme()
    {
        kacTaneKucukCemberOlsun--;
        if (kacTaneKucukCemberOlsun < 2)
        {
            bir.text = kacTaneKucukCemberOlsun + "";
            iki.text = "";
            uc.text = "";
        }
        else if (kacTaneKucukCemberOlsun < 3)
        {
            bir.text = kacTaneKucukCemberOlsun + "";
            iki.text = (kacTaneKucukCemberOlsun - 1) + "";
            uc.text = "";
        }
        else
        {
            bir.text = kacTaneKucukCemberOlsun + "";
            iki.text = (kacTaneKucukCemberOlsun - 1) + "";
            uc.text = (kacTaneKucukCemberOlsun - 2) + "";
        }

        if (kacTaneKucukCemberOlsun == 0)
        {
            StartCoroutine(yeniLevel());
        }
    }

    IEnumerator yeniLevel()
    {
        donenCember.GetComponent<Dondurme>().enabled = false; //çember tikini kaldýrýyoruz.
        anaCember.GetComponent<AnaCember>().enabled = false;
        yield return new WaitForSeconds(1);

        if (kontrol)
        {
            animator.SetTrigger("yenilevel");
            yield return new WaitForSeconds(1.4f);

            if (int.Parse(SceneManager.GetActiveScene().name) == 3)
            {
                SceneManager.LoadScene("Ana Menu");
            }
            else
            {
                SceneManager.LoadScene(int.Parse(SceneManager.GetActiveScene().name) + 1);
            }
            
            // int.Parse ile deðeri integer yapýyoruz.
        }
    }

    public void OyunBitti()
    {
        StartCoroutine(CagrilanMetot());
    }

    IEnumerator CagrilanMetot()
    {
        donenCember.GetComponent<Dondurme>().enabled = false; //çember tikini kaldýrýyoruz.
        anaCember.GetComponent<AnaCember>().enabled = false;
        animator.SetTrigger("oyunbitti");

        kontrol = false;

        yield return new WaitForSeconds(1); //1 saniye bekler  

        SceneManager.LoadScene("Ana Menu");
    }
}
