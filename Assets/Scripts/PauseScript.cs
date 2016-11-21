using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{

    [SerializeField]
    private GameObject pausePanel;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private bool bPause;

    // Use this for initialization
    void Start()
    {
        bPause = false;
    }

    void Update()
    {

        if (bPause)
        {
            PauseGame(true);

        }
        else
        {
            PauseGame(false);

        }

        if (Input.GetButtonDown("Cancel"))
        {
            SwitchPause();
        }

        if (Input.GetButtonDown("Submit"))
        {
            SceneManager.LoadScene(0);
        }

    }

    void PauseGame(bool state)
    {
        if (state)
        {
            Time.timeScale = 0.0f; //Paused
        }
        else
        {
            Time.timeScale = 1.0f; //Unpaused
        }

        pausePanel.SetActive(state);
    }

    void SwitchPause()
    {
        if (bPause)
        {
            bPause = false; //Changes the value
        }
        else
        {
            bPause = true;
        }
    }
}
