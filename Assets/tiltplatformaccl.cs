using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tiltplatformaccl : MonoBehaviour {
    bool isflat=true;
    public float RotateSpeed=6;
    Vector3 tilt;
    float desiredRot;
    public float damping= 10;
    

    // Use this for initialization
    void Start () {
        desiredRot = transform.eulerAngles.z;


    }
	
	// Update is called once per frame
	void Update () {

        // transform.Rotate(tilt.x*0,tilt.y *0, -tilt.x* RotateSpeed,Space.Self);
        //transform.localRotation(tilt.x * 0, tilt.y * 0, -tilt.x * RotateSpeed,Quaternion.identity);
        //transform.rotation = new Quaternion(tilt.x * 0, tilt.y * 0, -tilt.x*0.5f , 1f); //Input.gyro.attitude;
        
    }
    private void LateUpdate()
   
        
    {
       tilt = Input.acceleration;
        if(isflat){
            tilt = Quaternion.Euler(0, 0, 0)* tilt;

        }
        var desiredRotQ = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, desiredRot);
        desiredRotQ = new Quaternion(tilt.x * 0, tilt.y * 0, -tilt.x * 0.5f, 0.45f);
        transform.rotation =  Quaternion.Lerp(transform.rotation, desiredRotQ, Time.deltaTime*damping);
    }
}
