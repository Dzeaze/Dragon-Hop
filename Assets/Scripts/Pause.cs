using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject pauseScreen;
    public float timeScale;
    public GameObject gameCanvas;
    public GameObject startCanvas;

    // Start is called before the first frame update
    void Start()
    {
        timeScale = 1.1f;
        Time.timeScale = timeScale;
        pauseScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PauseButton()
    {
        Invoke("SetPause", 0.25f);
        pauseScreen.SetActive(true);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void SetPause()
    {
        Time.timeScale = 0;
    }

    public void ResumeButton()
    {
        Time.timeScale = timeScale;
        pauseScreen.SetActive(false);
    }

    public void RestartButton()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = timeScale;
        startCanvas.SetActive(false);
        gameCanvas.SetActive(true);
    }
}
