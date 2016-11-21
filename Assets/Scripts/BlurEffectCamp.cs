using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

public class BlurEffectCamp : MonoBehaviour
{
    private MotionBlur mMotionBlur;
    private NoiseAndGrain mNoiseNGrain;

    private SphereCollider mCollider;
    private Transform mPlayer;

    private bool mIsTriggered;


    // Use this for initialization
    void Start()
    {
        mMotionBlur = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MotionBlur>();
        mNoiseNGrain = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<NoiseAndGrain>();
        mPlayer = GameObject.FindGameObjectWithTag("Player").transform;
        mCollider = GetComponent<SphereCollider>();
        mIsTriggered = false;

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (!mIsTriggered)
        {
            if (other.tag == "Player")
            {
                mNoiseNGrain.enabled = true;
                mMotionBlur.enabled = true;
                mIsTriggered = true;
                mMotionBlur.blurAmount = 0f;
            }
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
            float blurAmount = (distance / 10f);

            Debug.Log("Blur amount: " + blurAmount);
            mMotionBlur.blurAmount = blurAmount;
            mNoiseNGrain.intensityMultiplier = blurAmount * 20f;
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
