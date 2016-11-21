using UnityEngine;
using System.Collections;

public class CrossHair : MonoBehaviour
{
    private Vector3 vectorStart;
    private Vector3 vectorTemp;
    private bool boolRayHit;
    private bool boolRayHitNote;
    private bool boolRayHitChest;
    private bool boolCheck = true;

    // Use this for initialization
    void Start()
    {
        vectorStart = gameObject.transform.localPosition;
        vectorTemp = vectorStart;

    }

    // Update is called once per frame
    void Update()
    {
        boolRayHit = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Raycast>().BoolRayHit;
        boolRayHitNote = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Raycast>().NoteHit;
        boolRayHitChest = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Raycast>().ChestHitBool;

        if (boolRayHit == true || boolRayHitNote == true || boolRayHitChest)
        {
            if (boolCheck != true)
            {
                vectorTemp = vectorStart;
                gameObject.transform.localPosition = vectorStart;
                boolCheck = true;
            }
        }
        else
        {
            if (boolCheck != false)
            {
                vectorTemp.y += 1000;
                gameObject.transform.localPosition = vectorTemp;
                boolCheck = false;
            }
        }
    }
}
