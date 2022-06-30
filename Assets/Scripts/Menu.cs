using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Start()
    {
        PlayerPrefs.DeleteAll();
        //kayýtlý oyunu siler
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

    public void cýk()
    {
        Application.Quit(); //oyundan çýkar
    }
}
