using UnityEngine;
using System.Collections;

//public class Pickup : MonoBehaviour {
//    private bool playerCollide = false;
//    private bool rayCast;
//    private GameObject myPlayer;

//    // using colliders to check if we are in range of the key to pick it up!!
//    void OnTriggerEnter(Collider myPlayer)
//    {

//        playerCollide = true;

//    }

//    void OnTriggerExit(Collider myPLayer)
//    {
//        playerCollide = false;

//    }

//    // Use this for initialization
//    void Start () {


//    // finding the player!
//    myPlayer = GameObject.FindGameObjectWithTag("Player");


//	}

//	// Update is called once per frame
//	void Update ()
//    {   //getting the Bool if we are hitting the right target
//        rayCast = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Raycast>().rayHitBool;

//        // if we look att the right object and we are within range of it we can pick it up!
//        if (rayCast == true)
//        {

//            if (Input.GetKey("e"))
//            {
//                //Debug.Log("Works", gameObject);
//                SeCode.myScore++;
//                myPlayer.GetComponent<SeCode>().PickUpAmount = myPlayer.GetComponent<SeCode>().PickUpAmount;
//                Debug.Log(SeCode.myScore+" out of "+ myPlayer.GetComponent<SeCode>().PickUpAmount + " Keys Found");
//                Destroy(gameObject);
//            }
//        }
//    }
//}
