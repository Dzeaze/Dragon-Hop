using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestScoreSaver : MonoBehaviour
{

    public GameObject scoreCount;
    private Text scoreText;

    public GameObject totalScore;
    private Text totalScoreText;

    



    // Start is called before the first frame update
    void Start()
    {


        
        scoreText = scoreCount.GetComponent<Text>();

        totalScoreText = totalScore.GetComponent<Text>();

        LoadBestScore();
         
    }

    void SaveBestScore()
    {
        PlayerPrefs.SetInt("BestScore", int.Parse(totalScoreText.text));
        
        PlayerPrefs.Save();
        
    }

    

    void LoadBestScore()
    {
        if (PlayerPrefs.HasKey("BestScore"))
        {
            totalScoreText.text = "" + PlayerPrefs.GetInt("BestScore");

        }
        else totalScoreText.text = "0";
    }

        // Update is called once per frame
        void Update()
    {
        if (int.Parse(totalScoreText.text) < int.Parse(scoreText.text))
        {
            totalScoreText.text = scoreText.text;
            SaveBestScore();
        }


    }
}
