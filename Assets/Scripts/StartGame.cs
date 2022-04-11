using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    public GameObject gameCanvas;
    public GameObject startCanvas;

    public GameObject shiftCamera;

    private Vector3 mainPosition;

    public GameObject platformGenerator;

    public Text bestScore;

    //private bool firstStarted;

   

    // Start is called before the first frame update
    void Start()
    {
        mainPosition = shiftCamera.transform.position;
        if (Time.realtimeSinceStartup < 3)
            StartGameScreen();
        else StartScreenOff();
    }

    void StartGameScreen()
    {
        bestScore.text = "" + PlayerPrefs.GetInt("BestScore");
        gameCanvas.SetActive(false);
        startCanvas.SetActive(true);
        platformGenerator.SetActive(false);
        //mainPosition = shiftCamera.transform.position;
        shiftCamera.transform.position = new Vector3(shiftCamera.transform.position.x - 3, shiftCamera.transform.position.y, shiftCamera.transform.position.z);
    }

    
    // Update is called once per frame
    void Update()
    {
        //print(Time.realtimeSinceStartup);
    }

    public void PlayButton()
    {
        StartScreenOff();
        //firstStarted = false;


    }

    void StartScreenOff()
    {
        startCanvas.SetActive(false);
        gameCanvas.SetActive(true);
        platformGenerator.SetActive(true);
        shiftCamera.transform.position = mainPosition;
    }
}
