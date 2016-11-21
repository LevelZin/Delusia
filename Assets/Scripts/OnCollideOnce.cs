using UnityEngine;
using System.Collections;

public class OnCollideOnce : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;

    private bool mIsPlayed;

    public void Awake()
    {
        source = GetComponent<AudioSource>();
        mIsPlayed = false;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (!mIsPlayed)
        {
            source.Play();
            mIsPlayed = true;
        }
    }
}