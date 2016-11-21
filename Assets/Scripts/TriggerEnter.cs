using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

public class TriggerEnter : MonoBehaviour
{

    private MotionBlur mBlur;
    private NoiseAndGrain mNoise;
    private bool isTriggered;

    void Start()
    {
        mBlur = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MotionBlur>();
        mNoise = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<NoiseAndGrain>();
        mBlur.enabled = false;
        mNoise.enabled = false;
        isTriggered = false;
    }

    void OnTriggerEnter(Collider Col)
    {
        if (!isTriggered)
        {
            if (Col.tag == "Player")
            {
                mNoise.enabled = true;
                mBlur.enabled = true;
                isTriggered = true;

            }
        }
    }
}

