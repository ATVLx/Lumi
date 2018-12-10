using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallwhenhit : MonoBehaviour {

    Rigidbody rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>(); 
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Collision");
            rb.useGravity = true;
        }
        if (other.gameObject.tag == "deadZone")
        {
            Debug.Log("obj deleted in collision");
            //rb.useGravity = true;
        }
    }
    void OnTriggerEnter(Collider other)
    {
       
        if (other.tag == "Player")
        {
            Debug.Log("trigger");
            rb.useGravity = true;
        }
        if (other.tag == "deadZone")
        {
            Debug.Log(" object deleted in trigger mode");
            Destroy(gameObject);
        }
    }
}
