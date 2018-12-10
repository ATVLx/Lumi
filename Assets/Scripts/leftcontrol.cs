using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Events;

public class leftcontrol : MonoBehaviour, IPointerUpHandler ,IPointerDownHandler {

    private bool pointerdown;
    //private bool pointerUP;
    float left;
    
	// Use this for initialization
	
   

    public void OnPointerDown(PointerEventData eventData)
    {
//        Debug.Log("pointer true");
        pointerdown = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        pointerdown = false;
        left = 0;
    }

    // Update is called once per frame
    void Update () {
		
	}

    public float Onleft(){
        if(pointerdown == true)
        {
//            Debug.Log("getting values");
            left = 1;
        }
        if (pointerdown == false)
        {
            left = 0;
        }
        return left;

    }

}
