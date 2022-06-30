using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Start()
    {
        PlayerPrefs.DeleteAll();
        //kay�tl� oyunu siler
    }
    public void oyunaGit()
    {
        int kayitliLevel = PlayerPrefs.GetInt("kayit");

        if (kayitliLevel == 0)
        {
            SceneManager.LoadScene(kayitliLevel+1);
        }
        else
        {
            SceneManager.LoadScene(kayitliLevel);
        }
        
    }

    public void c�k()
    {
        Application.Quit(); //oyundan ��kar
    }
}
