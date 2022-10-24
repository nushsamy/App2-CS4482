using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public string firstLevel;
    public string dashboard;

    public TMPro.TMP_InputField nameInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        if(nameInput.text.Length < 3 || nameInput.text.Length > 15)
        {
            Debug.Log("Name must be between 3 and 15 characters");
        } else
        {
            PlayerName.finalPlayerName = nameInput.text;
            SceneManager.LoadScene(firstLevel);
        }
        
    }

    public void OpenDashboard()
    {
        SceneManager.LoadScene(dashboard);

    }

    public void ExitGame()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
