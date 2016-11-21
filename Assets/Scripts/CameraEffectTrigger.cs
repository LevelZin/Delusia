using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

public class CameraEffectTrigger : MonoBehaviour
{

    private MotionBlur mBlur;
    private NoiseAndGrain mNoise;

    void Start()
    {
        mBlur = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MotionBlur>();
        mNoise = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<NoiseAndGrain>();
        mBlur.enabled = false;
        mNoise.enabled = false;
    }

    void OnTriggerEnter(Collider Col)
    {
        Debug.Log(Col.tag);
        if (Col.tag == "Player")
        {
            mNoise.enabled = true;
            mBlur.enabled = true;
        }
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
