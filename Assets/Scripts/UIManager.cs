using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> heartsList;
    [SerializeField] private Text text;
    [SerializeField] private GameObject loseScreen;
    [SerializeField] private GameObject waitPanel;
    private int hearts;
    private int score = 0;

    private void Awake()
    {
        SpawnedDepartment.OnDamageReceived += UpdateHearts;
        SpawnedDepartment.OnCorrectLanding += UpdateScore;
        hearts = 3;
    }

    private void Update()
    {
        if(text != null)
        text.text = score.ToString();
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
                waitPanel.SetActive(true);
                StartCoroutine(Wait());
                SpawnedDepartment.OnDamageReceived -= UpdateHearts;
                SpawnedDepartment.OnCorrectLanding -= UpdateScore;
                break;
        }
    }

    private void UpdateScore()
    {
        score++;
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
        SpawnedDepartment.OnCorrectLanding -= UpdateScore;
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
        SceneManager.LoadScene(scene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public int GetScore()
    {
        return score;
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
        Time.timeScale = 1;
        loseScreen.SetActive(true);
    }

}
