using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermove : MonoBehaviour {
   // public GameObject player;
	// Use this for initialization
	
    private void OnTriggerEnter(Collider col)
    {

            Debug.Log("entered");
            col.transform.parent = gameObject.transform;
        FindObjectOfType<playerfollow>().OnSmoothcam();
       
    }
    private void OnTriggerExit(Collider col)
    {
        col.transform.parent = null;
        FindObjectOfType<playerfollow>().OnUnsmoothcam();
    }
}
