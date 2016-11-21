using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class KillBox : MonoBehaviour {
    private GameObject mPlayer;

    void Start()
    {
        mPlayer = GameObject.FindGameObjectWithTag("Player");
    }

	void OnTriggerEnter (Collider other)
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadScene("main_level");
        }
	}
}