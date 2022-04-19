using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;
using UnityEngine.UI;
using TMPro;

public class Highscores : MonoBehaviour
{
    [SerializeField] private InputField MemeberID;
    [SerializeField] private int score;
    [SerializeField] private int ID;
    [SerializeField] private int maxScores = 5;
    [SerializeField] TextMeshProUGUI[] entries;
    [SerializeField] UIManager UIM;
    [SerializeField] TextMeshProUGUI ownScore;
    [SerializeField] Button bttn;

    private void Start()
    {
        LootLockerSDKManager.StartGuestSession("Player", (response) =>
        {
            if (response.success)
            {
                score = UIM.GetScore();
                ownScore.text = score.ToString();
                Debug.Log("Success");
            }
            else
            {
                Debug.Log("Failed");
            }
        });
        ShowScores();
    }

    public void ShowScores()
    {
        LootLockerSDKManager.GetScoreList(ID, maxScores, (response) =>
        {
            if (response.success)
            {
                LootLockerLeaderboardMember[] scores = response.items;

                for (int i = 0; i < scores.Length; i++)
                {
                    entries[i].text = (scores[i].member_id + ".   " + scores[i].score);

                }
            }
            else
            {
                Debug.Log("Fail");
            }
        });
    }

    public void SumbitScore()
    {
        bttn.interactable = false;
        LootLockerSDKManager.SubmitScore(MemeberID.text, score, ID, (response) =>
        {
            if (response.success)
            {
                Debug.Log("Success");
            }
            else
            {
                Debug.Log("Fail");
            }
        });
    }
}

