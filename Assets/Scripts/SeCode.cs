using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SeCode : MonoBehaviour
{
    [SerializeField]
    private float floatTextTimer = 0.0f;
    [SerializeField]
    private int intKeyCap = 3;
    private bool boolKeyText = false;
    private bool boolKeyCollected = false;
    private int intKeyCounter;

    public int KeyCounter
    {
        get { return intKeyCounter; }
        set { intKeyCounter = value; }
    }

    public int KeyCap
    {
        get { return intKeyCap; }
        set
        {
            intKeyCap = value;
            boolKeyText = true;
            floatTextTimer = 10.0f;
        }
    }

    // Use this for initialization
    void Start()
    {
        intKeyCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // using boolKeyCollected (score Check) to let us know when we collected all of the keys!
        if (intKeyCounter >= intKeyCap && boolKeyCollected == false)
        {
            Debug.Log("Done");
            boolKeyCollected = true;
        }

        if (floatTextTimer >= 0.0f && boolKeyText == true)
        {
            floatTextTimer -= Time.deltaTime;
        }
        else if (boolKeyText == true)
        {
            boolKeyText = false;
        }
    }

    void OnGUI()
    {
        if (boolKeyText == true)
        {
            GUI.Label(new Rect(Screen.width / 2 - 65, Screen.height / 5, 200, 20), intKeyCounter + " out of " + KeyCap + " Keys Found");
        }
    }
}
