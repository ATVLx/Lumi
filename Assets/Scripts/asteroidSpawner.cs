using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidSpawner : MonoBehaviour {

    public GameObject asteroid;
    bool spawned=false;
    Vector3 pos;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
       pos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        if (Input.GetKeyDown(KeyCode.F)){
            Instantiate(asteroid,pos,Quaternion.identity);
        }
		
	}
   public void Spawn()
    {
        if(spawned == false){
            Instantiate(asteroid, pos, Quaternion.identity);
            spawned = true;
            StartCoroutine(watiforreset());
        }

       // if not then reset bool in coroutine//
    }
    IEnumerator watiforreset(){
        yield return new WaitForSeconds(1);
        spawned = false;
    }
}
