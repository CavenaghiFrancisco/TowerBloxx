using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> heartsList;
    private int hearts;

    private void Awake()
    {
        SpawnedDepartment.OnDamageReceived += UpdateHearts;
        hearts = 3;
    }

    private void Update()
    {
        Debug.Log(hearts);
    }

    private void UpdateHearts()
    {
        hearts--;
        switch (hearts)
        {
            case 2:
                heartsList[0].SetActive(false);
                break;
            case 1:
                heartsList[1].SetActive(false);
                break;
            case 0:
                heartsList[2].SetActive(false);
                Time.timeScale = 0;
                SpawnedDepartment.OnDamageReceived -= UpdateHearts;
                SceneManager.LoadScene(0);
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
        SpawnedDepartment.OnDamageReceived -= UpdateHearts;
        if(Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
        SceneManager.LoadScene(scene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
