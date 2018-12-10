using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Events;

public class rightcontrol : MonoBehaviour, IPointerUpHandler, IPointerDownHandler{

    private bool pointerdown;
    //private bool pointerUP;
    float right ;
    // Use this for initialization
    public void OnPointerDown(PointerEventData eventData)
    {
//        Debug.Log("pointer true");
        pointerdown = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        pointerdown = false;
        right = 0;
    }

    public float OnRight()
    {
        if (pointerdown == true)
        {
//            Debug.Log("getting values");
            right = 1;
        }
        if(pointerdown==false){
            right = 0;
        }
        return right;

    }
}
