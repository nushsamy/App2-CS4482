using UnityEngine.UI;
using LootLocker.Requests;
using UnityEngine;

public class LeaderboardController : MonoBehaviour
{
    public InputField MemberID, PlayerScore;
    public int ID;
    int maxScores = 5;
    public TMPro.TMP_Text[] entries;

    void Start()
    {
        LootLockerSDKManager.StartGuestSession((response) =>
        {

            if (response.success)
            {
                Debug.Log("Success");
                ShowScores();
            } else
            {
                Debug.Log("Failed");
            }
        });

        
    }

    public void SubmitScore()
    {
        if(PlayerName.finalPlayerName != null && PlayerName.gameComplete)
        {
            LootLockerSDKManager.SubmitScore(PlayerName.finalPlayerName, (int)TimerScript.timeRemaining, ID, (response) => {
                if (response.success)
                {
                    Debug.Log("Success");
                    ShowScores();
                }
                else
                {
                    Debug.Log("Failed");
                }
            });

            PlayerName.finalPlayerName = null;
            TimerScript.timeRemaining = 120;

        } else
        {
            Debug.Log("Invalid player name or score");
        }

        Debug.Log("Request Sent");
    }

    public void ShowScores()
    {
        LootLockerSDKManager.GetScoreList(ID, maxScores, (response) =>
        {
            if (response.success)
            {
                LootLockerLeaderboardMember[] scores = response.items;

                for(int i = 0; i < scores.Length; i++)
                {
                    entries[i].text = (scores[i].rank + ".   " + scores[i].member_id + "   " + scores[i].score);
                }

                if(scores.Length < maxScores)
                {
                    for(int i = scores.Length; i < maxScores; i++)
                    {
                        entries[i].text = (i + 1).ToString() + ".   none";
                    }
                }
            }
            else
            {
                Debug.Log("Failed");
            }

        });
    }
}
