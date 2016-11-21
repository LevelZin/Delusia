using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class snapshotTransition : MonoBehaviour
{

    [SerializeField]
    private AudioMixerSnapshot audioBeach;
    [SerializeField]
    private AudioMixerSnapshot audioJungle;
    [SerializeField]
    private AudioMixerSnapshot audioCloseBeach;
    [SerializeField]
    private float fTime;
    private bool boolBeach;
    private bool boolJungle;
    private bool boolCloseBeach;


    void Start()
    {
        boolBeach = true;
        boolJungle = false;
        boolCloseBeach = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (boolBeach == true)
            {
                audioCloseBeach.TransitionTo(fTime);
                boolBeach = false;
                boolCloseBeach = true;
                boolJungle = false;
            }
            else if (boolCloseBeach == true)
            {
                audioJungle.TransitionTo(fTime);
                boolBeach = false;
                boolCloseBeach = false;
                boolJungle = true;
            }
            else if (boolJungle == true)
            {
                audioBeach.TransitionTo(fTime);
                boolBeach = true;
                boolCloseBeach = false;
                boolJungle = false;
            }
        }
    }
}
