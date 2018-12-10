using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerfollow : MonoBehaviour {

    // Use this for initialization
    public Transform target;
    public float smoothness=0.1f;
    private Vector3 cameraOffset= new Vector3 (0,1,-7.3f);
    private bool cameraset = false;
   // int additionaloffset = 3;

    public void changecameraview(){
        //Debug.Log("change cam view called");
        if (!cameraset){
           // Debug.Log("cameraset turned true");
            cameraset = true;
            cameraOffset = new Vector3(0, 0.5f, -11);

           // Debug.Log(cameraOffset);
        }
        else if(cameraset){
            Debug.Log("cameraset turned false");
            cameraset = false;
            cameraOffset = new Vector3(0, 0.5f, -7.3f);
            cameraset = false;
//            Debug.Log(cameraOffset);
        }


    }
    private void Start()
    {
        cameraOffset = new Vector3(0, 1, -7.3f);
        cameraset = false;
    }

    private void FixedUpdate()
    {
        Vector3 desiredpos = target.position + cameraOffset;
        Vector3 smoothedpos = Vector3.Lerp(transform.position, desiredpos, smoothness);
        transform.position = smoothedpos;
        //transform.LookAt(target);
    }
   public void OnSmoothcam(){
        smoothness = 0.5f;

    }
    public void  OnUnsmoothcam()
    {
        smoothness = 0.1f;
    }

}
