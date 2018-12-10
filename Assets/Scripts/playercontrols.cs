using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class playercontrols : MonoBehaviour {
    public GameObject PLAYER;
    public float speed=3;
    public float rigidbodyspeed=20;
    Rigidbody rb;
    public float force;
    public int JumpsRemaining=2;
    public TextMeshProUGUI jumpsdisplay;
    public leftcontrol left;
    public rightcontrol right;
    public GameObject showwarning;
    public GameObject Warninglight;
    bool ignoreWarning=false;
    bool warninglighttoggle= true;
   
    float a;
    float b;
 
	// Use this for initialization
	void Start () {
        showwarning.SetActive(false);
        rb = GetComponent<Rigidbody>();
        Time.timeScale = 1;
        Warninglight.SetActive(false);
	}
    private void LateUpdate()
    {
        jumpsdisplay.text = JumpsRemaining + "";



       
        if (a > 0)
        {
            transform.Translate(-a * speed * Time.deltaTime, 0, 0);
            rb.AddForce(-a * rigidbodyspeed/0.75f * 3, 0, 0);
        }
        //transform.Translate(-a * speed , 0, 0);
        if (b > 0)
        {
            transform.Translate(b * speed * Time.deltaTime, 0, 0);
            rb.AddForce(b * rigidbodyspeed / 0.75f * 3, 0, 0);
        }


        
    }

    IEnumerator wariningOn(){
        if(warninglighttoggle)
        {
        yield return new WaitForSeconds(0.25f);
        Warninglight.SetActive(true);
        StartCoroutine(wariningOff());
        }
    }
    IEnumerator wariningOff()
    {
        if (warninglighttoggle)
        {
            yield return new WaitForSeconds(0.25f);
            Warninglight.SetActive(false);
           
            StartCoroutine(wariningOn());
            StartCoroutine(turnwarningOff());

        }
        else yield return null;
    }
    IEnumerator turnwarningOff(){
        yield return new WaitForSeconds(3);
        warninglighttoggle = false;
        StopCoroutine(wariningOn());
        StopCoroutine(wariningOff());
        warninglighttoggle = false;
        Debug.Log("called for stop");
        //Warninglight.SetActive(false);
        //StopCoroutine(turnwarningOff());
    }

    public void OnvideoPlayYesClick(){
        Debug.Log("Called Yes");
        Admanager.Instance.ShowRewardedvideo();
        Admanager.Instance.ShowVideo();
        JumpsRemaining = 2;

    }
    public void OnvideoPlayNoClick()
    {
        Debug.Log("Called No");
        //Admanager.Instance.ShowRewardedvideo();
        ignoreWarning = true;

    }

    // Update is called once per frame
    void Update () {
        //float a;
        //float b;
        // transform.Translate(b * speed , 0, 0);
         a = left.Onleft();
         b = right.OnRight();
        if (Input.GetButton("Horizontal")){
             a = Input.GetAxis("Horizontal");
            if(a<0){
                transform.Translate(a*speed*Time.deltaTime,0,0);
                //rb.AddForce(a * speed*3 , 0, 0);
            }
            if (a > 0)
            {
             transform.Translate(a*speed * Time.deltaTime, 0, 0);
              //  rb.AddForce(a * speed*3 , 0, 0);
            }
        }
        if (Input.GetButtonDown("Jump")){
            Debug.Log("jump");
            if (JumpsRemaining > 0)
            {
                rb.AddForce(0, force, 0);
                JumpsRemaining--;

            }
            else 
            Debug.Log("jumps Over jumpsremaining: "+JumpsRemaining);

           /* if (JumpsRemaining == 0 || ignoreWarning == false)
            {
                showwarning.SetActive(true);
            }
            else showwarning.SetActive(false);*/

            //transform.Translate(0, force , 0);

        }
        if (JumpsRemaining <= 0 && ignoreWarning == false)
        {
            showwarning.SetActive(true);
        }
        else showwarning.SetActive(false);
    }
    public void OnLeftClick()
    {
        transform.Translate(-1 * speed * Time.deltaTime, 0, 0);
    }
    public void OnrightClick()
    {
        transform.Translate(1 * speed * Time.deltaTime, 0, 0);
    }
    public void OnJumpClick()
    {
        if (JumpsRemaining > 0)
        {
            rb.AddForce(0, force, 0);
            JumpsRemaining--;

        }
    }

    public void OnLeftClickUp()
    {
      //  transform.Translate(-1 * speed * Time.deltaTime, 0, 0); do nothing
    }
    public void OnrightClickUp()
    {
       // transform.Translate(1 * speed * Time.deltaTime, 0, 0); do nothing
    }

    public void CheckPoint()
    {
        PlayerPrefs.SetFloat("PositionX", transform.position.x);
        PlayerPrefs.SetFloat("PositionY", transform.position.y);
        PlayerPrefs.SetFloat("PositionZ", transform.position.z);
        Debug.Log("checkPoint ;)");
        Debug.Log(PlayerPrefs.GetFloat("PositionX")+""+PlayerPrefs.GetFloat("PositionY")+""+ PlayerPrefs.GetFloat("PositionZ"));
    }


    public void ApplyCheckPoint(){
        PLAYER.transform.position = new Vector3(PlayerPrefs.GetFloat("PositionX")+1, PlayerPrefs.GetFloat("PositionY"), PlayerPrefs.GetFloat("PositionZ"));
        Time.timeScale = 1;
        JumpsRemaining = 2;
        Admanager.Instance.ShowRewardedvideo();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="morejump")
        {
            JumpsRemaining += 3;
        }
        if (other.tag == "deadZone")
        {
            Debug.Log("Dead");
            //Time.timeScale = 0;
            //UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
            //JumpsRemaining += 3;
            FindObjectOfType<GameManager>().OnGameOver();
        }
        if (other.tag == "checkpoint"){
            CheckPoint();
        }

        if (other.tag == "asteroid")
        {
            warninglighttoggle = true;
            FindObjectOfType<asteroidSpawner>().Spawn();
            StopCoroutine(wariningOn());
            StopCoroutine(wariningOff());
            StopCoroutine(turnwarningOff());
            StartCoroutine(wariningOn());
            //StartCoroutine(turnwarningOff());
            //warninglighttoggle = true;
        }
        if (other.tag == "finish")
        {
            FindObjectOfType<GameManager>().OnStageChange();
            Admanager.Instance.ShowVideo();

        }

    }
    private void OnCollisionEnter(Collision hit)
    {
        if(hit.gameObject.tag== "asteroidhit")
        {
            FindObjectOfType<GameManager>().OnGameOver();
        }
    }
}
