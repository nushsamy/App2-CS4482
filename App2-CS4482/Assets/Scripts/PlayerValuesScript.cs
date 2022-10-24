using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerValuesScript : MonoBehaviour
{

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onComplete()
    {

        float score = TimerScript.timeRemaining;
        Debug.Log(score);
        SceneManager.LoadScene("Leaderboard");

    }
}
