using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public GameObject GameOverPanel;
    public GameObject PausePanel;
    public GameObject PauseBtn;
    public GameObject CAmControls;
    public GameObject Leftdir;
    public GameObject Rightdir;
    public GameObject Updir;
    public GameObject Paneltohide;

    public GameObject textshw;
    public Animator anim;
    public Animator anim1;
    public Animator anim2;
    public Animator anim3;
    public Animator anim4;
    public Animator anim5;
    int count = 0;

    // Use this for initialization
    void Start () {
        Paneltohide.SetActive(true);
        Time.timeScale = 1;
        //Debug.Log("😀grinning face Unicode: U + 1F600, UTF - 8: F0 9F 98 80");
        StartCoroutine(Waittoload());
        Leftdir.SetActive(false);
        Rightdir.SetActive(false);
        Updir.SetActive(false);
        PauseBtn.SetActive(false);
        CAmControls.SetActive(false);
        Debug.Log("Start Fx Made Exit");
        Admanager.Instance.ShowBanner();

    }
	

    public void OnGameOver(){
        if(PausePanel.active){
            PausePanel.SetActive(false);
        }
        GameOverPanel.SetActive(true);
        CAmControls.SetActive(false);
        PauseBtn.SetActive(false);
        Time.timeScale = 0;
        Leftdir.SetActive(false);
        Rightdir.SetActive(false);
        Updir.SetActive(false);
        Admanager.Instance.ShowVideo();
    }
    public void OnPauseClick()
    {
        textshw.SetActive(true);
        PausePanel.SetActive(true);
        CAmControls.SetActive(false);
        Leftdir.SetActive(false);
        Rightdir.SetActive(false);
        Updir.SetActive(false);
        PauseBtn.SetActive(false);
        Time.timeScale = 0;
        Admanager.Instance.ShowVideo();
    }
    public void OnPausebackClick()
    {

        textshw.SetActive(false);
        CAmControls.SetActive(true);
        PauseBtn.SetActive(true);
        Leftdir.SetActive(true);
        Rightdir.SetActive(true);
        Updir.SetActive(true);
        Time.timeScale = 1;
        StartCoroutine(WaitForAnimtoDiepause());
        anim.SetTrigger("Exit");
        anim1.SetTrigger("Exit");
        anim2.SetTrigger("Exit");
        anim3.SetTrigger("Exit");
        anim4.SetTrigger("Exit");


    }

    public void OnRestartClick()
    {
       int a = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(a);

    }
    public void OnEXITClick()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
        Admanager.Instance.ShowVideo();

    }
    public void OnResumeCLICK(){
        OnPausebackClick();
    }


    IEnumerator WaitForAnimtoDiepause(){
        yield return new WaitForSeconds(1.1f);

        PauseBtn.SetActive(true);
        PausePanel.SetActive(false);
        Time.timeScale = 1;

    }
    IEnumerator Waittoload()
    {
        yield return new WaitForSeconds(2.5f);
        Leftdir.SetActive(true);
        Rightdir.SetActive(true);
        Updir.SetActive(true);
        PauseBtn.SetActive(true);
        CAmControls.SetActive(true);
        Paneltohide.SetActive(false);
        Debug.Log("called waittoload");

    }

    IEnumerator WaitforReset(){
        yield return new WaitForSeconds(1);
        count = 0;
        //Reset quick backbuttion functionality!
    }

        // Update is called once per frame
    void Update () {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            count++;
            OnPauseClick();
            StartCoroutine(WaitforReset());
        }
        if(count>3){
            SceneManager.LoadScene("Menu");

        }
		//BackBution Functions
	}
    public void OnRestartFromCheckPoint()
    {
  
        FindObjectOfType<playercontrols>().ApplyCheckPoint();
        Checkpointcontinue();
        Admanager.Instance.ShowRewardedvideo();
        Admanager.Instance.ShowVideo();

    }
    public void Checkpointcontinue(){
        Time.timeScale = 1;
        GameOverPanel.SetActive(false);
        CAmControls.SetActive(true);
        PauseBtn.SetActive(true);
        Leftdir.SetActive(true);
        Rightdir.SetActive(true);
        Updir.SetActive(true);

        anim.SetTrigger("Exit");
        anim1.SetTrigger("Exit");
        anim2.SetTrigger("Exit");
        anim3.SetTrigger("Exit");
        anim4.SetTrigger("Exit");

    }
    public void OnStageChange(){
        int a = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(a+1);


    }
}
