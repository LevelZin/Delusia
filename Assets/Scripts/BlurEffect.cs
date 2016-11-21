using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

/*
Script by Maria

Used for trigger visual effects.
*/

public class BlurEffect : MonoBehaviour
{
    private MotionBlur mMotionBlur;
    private NoiseAndGrain mNoiseNGrain;

    private SphereCollider mCollider;
    private Transform mPlayer;




    // Use this for initialization
    void Start()
    {
        mMotionBlur = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MotionBlur>();
        mNoiseNGrain = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<NoiseAndGrain>();
        mPlayer = GameObject.FindGameObjectWithTag("Player").transform;
        mCollider = GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            mNoiseNGrain.enabled = true;
            mMotionBlur.enabled = true;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            Vector3 pPos = mPlayer.position;
            Vector3 pos = this.transform.position;

            float distance = Vector3.Distance(pPos, pos);

            Debug.Log("Distance: " + distance);
            float blurAmount = 1f - (distance / 25f);//mCollider.radius * transform.parent.localScale.x;

            Debug.Log("Blur amount: " + blurAmount);
            mMotionBlur.blurAmount = blurAmount;
            mNoiseNGrain.intensityMultiplier = blurAmount * 10.0f;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            mNoiseNGrain.enabled = false;
            mMotionBlur.enabled = false;
        }
    }
}
