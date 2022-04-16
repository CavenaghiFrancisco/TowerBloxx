using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private int hearts = 3;

    private void Awake()
    {
        SpawnedDepartment.OnDamageReceived += UpdateHearts;
    }


    private void UpdateHearts()
    {
        hearts--;
        switch (hearts)
        {
            case 2:
                gameObject.transform.GetChild(5).gameObject.SetActive(false);
                break;
            case 1:
                gameObject.transform.GetChild(4).gameObject.SetActive(false);
                break;
            case 0:
                gameObject.transform.GetChild(3).gameObject.SetActive(false);
                break;
        }
    }

    public void StopGame()
    {
        if(Time.timeScale == 1)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
        gameObject.transform.GetChild(8).gameObject.SetActive(!gameObject.transform.GetChild(8).gameObject.activeSelf);

    }

    public void ChangeScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
