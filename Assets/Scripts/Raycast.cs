using UnityEngine;
using System.Collections;

public class Raycast : MonoBehaviour
{
    [SerializeField]
    private float floatRayRange = 50.0f;
    [SerializeField]
    private float timerDelay = 0.5f;
    [SerializeField]
    private Camera playerCamera;
    private bool boolNoteDisplay = false;
    private bool boolRayHit = false;
    private bool boolRayHitNote = false;
    private bool boolRayHitChest = false;
    private bool boolChestTrigger = false;
    private float floatTimer;
    private int intCounterKey;
    private GameObject objPlayer;
    private Texture textureNote;
    private RaycastHit rayHit;

    public bool ChestHit
    {
        get { return boolRayHitChest; }
    }

    public bool ChestHitBool
    {
        get { return boolChestTrigger; }
    }

    public bool NoteHit
    {
        get { return boolRayHitNote; }

        set { boolRayHitNote = value; }
    }
    public bool BoolRayHit
    {
        get { return boolRayHit; }

        set { boolRayHit = value; }
    }


    // Use this for initialization
    void Start()
    {
        objPlayer = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        if (floatTimer > 0)
        {
            floatTimer -= Time.deltaTime;
        }

        //set the ray to start from center of camera!
        Ray ray = playerCamera.ScreenPointToRay(new Vector2(Screen.width / 2.0f, Screen.height / 2.0f));

        //draws out the ray in the scene
        Debug.DrawRay(ray.origin, ray.direction * floatRayRange, Color.red);

        // get the things we want and sets our Bool to true once else it will be false!
        if (Physics.Raycast(ray, out rayHit, floatRayRange) && rayHit.transform.gameObject.tag == "pickup")
        {
            if (BoolRayHit != true)
            {
                BoolRayHit = true;
            }
        }
        else if (BoolRayHit != false)
        {
            BoolRayHit = false;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////
        if (Physics.Raycast(ray, out rayHit, floatRayRange) && rayHit.transform.gameObject.tag == "note")
        {
            if (boolRayHitNote != true)
            {
                Debug.Log("hitting note");
                boolRayHitNote = true;
                textureNote = rayHit.transform.GetComponent<noteScript>().TextureNote;
            }

        }
        else if (boolRayHitNote != false)
        {
            boolRayHitNote = false;
        }

        if (Physics.Raycast(ray, out rayHit, floatRayRange) && rayHit.transform.gameObject.tag == "chest")
        {

            if (boolChestTrigger != true)
            {
                boolChestTrigger = true;
            }
            if (boolChestTrigger == true && Input.GetKeyDown("e"))
            {
                boolRayHitChest = true;
                Debug.Log("rayHit");
            }

        }
        else if (boolChestTrigger != false)
        {
            boolRayHitChest = false;
            boolChestTrigger = false;
        }


        // if we look att the right object and we are within range of it we can pick it up!
        if (BoolRayHit == true)
        {
            if (Input.GetKey("e"))
            {
                intCounterKey = intCounterKey + 1;
                objPlayer.GetComponent<SeCode>().KeyCounter = intCounterKey;
                objPlayer.GetComponent<SeCode>().KeyCap = objPlayer.GetComponent<SeCode>().KeyCap;
                Debug.Log(intCounterKey + " out of " + objPlayer.GetComponent<SeCode>().KeyCap + " Keys Found");
                Destroy(rayHit.transform.gameObject);
            }
        }
    }

    void OnGUI()
    {

        if (boolRayHitNote == true && boolNoteDisplay == false && Input.GetKeyDown("e"))
        {
            floatTimer = timerDelay;
            boolNoteDisplay = true;
            Destroy(rayHit.transform.gameObject);
        }

        if (boolNoteDisplay == true)
        {
            GUI.Label(new Rect(Screen.width / 2 - textureNote.width / 2, 0, Screen.height / 2, Screen.width / 2), textureNote);

            if (Input.GetKeyDown("e") && floatTimer <= 0)
            {
                boolNoteDisplay = false;

            }

        }
    }
}
