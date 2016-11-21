using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

/*
Script by Maria

Deactivates visual effects.
*/

public class TriggerExit : MonoBehaviour
{

    private MotionBlur mBlur;
    private NoiseAndGrain mNoise;
    private bool isTriggered;

    void Start()
    {
        mBlur = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MotionBlur>();
        mNoise = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<NoiseAndGrain>();
    }

    void OnTriggerExit(Collider Col)
    {
        if (Col.tag == "Player")
        {
            mBlur.enabled = false;
            mNoise.enabled = false;
        }
    }
}