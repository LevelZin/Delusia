using UnityEngine;
using System.Collections;

public class ChestOpen : MonoBehaviour
{


    [SerializeField]
    private bool mChestOpen = false;
    private Animation animChest;
    private bool boolChestHit;
    private int intKeyCap = 0;
    private int intKeyCount;

    void Start()
    {
        animChest = GetComponent<Animation>();
        animChest["ChestAnim"].wrapMode = WrapMode.ClampForever;
    }

    void Update()
    {
        intKeyCount = GameObject.FindGameObjectWithTag("Player").GetComponent<SeCode>().KeyCounter;
        intKeyCap = GameObject.FindGameObjectWithTag("Player").GetComponent<SeCode>().KeyCap;
        boolChestHit = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Raycast>().ChestHit;

        if (intKeyCount >= intKeyCap && boolChestHit == true)
        {
            mChestOpen = true;
        }

        if (mChestOpen == true)
        {
            gameObject.GetComponent<Collider>().enabled = false;
            GetComponent<Animation>().Play("ChestAnim");
        }
    }
}
