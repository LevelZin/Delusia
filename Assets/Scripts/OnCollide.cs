using UnityEngine;
using System.Collections;

public class OnCollide : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;

    public void Awake()
    {
        source = GetComponent<AudioSource>();

    }

    public void OnTriggerEnter(Collider other)
    {
        source.Play();         
    }
}
