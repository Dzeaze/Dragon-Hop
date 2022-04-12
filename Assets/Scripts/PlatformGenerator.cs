using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlatformGenerator : MonoBehaviour
{
    public GameObject ThePlatform;
    //public GameObject ThePlatforms;
    public GameObject count;
    public Transform GenerationPoint;
    public float DistanceBetween;

    private float PlatformWidth;
    private float DistanceGenerating;
    private string PlatformCount;
    public int PlatformCountNumber = 0;

    private float DistanceGeneratingBalance;
    private float AchievementBalance;
    //GameObject instanceCount;
    //private GameObject achievement;
    public GameObject jump1Limit;
    public GameObject meteorite;

    private int[] distances;

    private int lastMeteoritePlatform;

    
    private int currentDistance;

    bool case3;
    bool case5;

    // Start is called before the first frame update
    void Start()
    {
        PlatformWidth = ThePlatform.GetComponent<BoxCollider2D>().size.x;
        //print("PlatformWidth=" + PlatformWidth);

        
        distances = new int[] { 1, 1, 1, 1 };
        
        
        currentDistance = 0;

    }

    private void GeneratePlatfrom()
    {
        if (transform.position.x < GenerationPoint.position.x)
        {
            DistanceGeneratingBalance = Random.Range(1, 101);
            AchievementBalance = Random.Range(1, 101);
            //print(DistanceGeneratingBalance);

            

            if (DistanceGeneratingBalance >= 1 && DistanceGeneratingBalance <= 65)
                {
                    PlatformCountNumber = PlatformCountNumber + 1;
                    GenerateByDistance(1);

                }
                
            else if (DistanceGeneratingBalance > 65 && DistanceGeneratingBalance <= 90)
                {
                    PlatformCountNumber = PlatformCountNumber + 2;
                    GenerateByDistance(2);

                }
            else if (DistanceGeneratingBalance > 90 && DistanceGeneratingBalance <= 100)
                {
                    PlatformCountNumber = PlatformCountNumber + 3;
                    GenerateByDistance(3);

                }

            if (AchievementBalance > 90)
                ThePlatform.transform.GetChild(1).gameObject.SetActive(true);
            else ThePlatform.transform.GetChild(1).gameObject.SetActive(false);


            count.GetComponent<TextMeshPro>().text = "" + PlatformCountNumber;
            Instantiate(ThePlatform, transform.position, transform.rotation);
            




        }
    }

    private void SmartGeneratePlatfrom()
    {
        if (transform.position.x < GenerationPoint.position.x)
        {
            DistanceGeneratingBalance = Random.Range(1, 101);
            AchievementBalance = Random.Range(1, 101);

            

            

            bool case5 = distances[0] == 3 && distances[1] == 1 && distances[2] == 2 && distances[3] == 1;
            bool case3 = distances[2] == 3 && distances[3] == 1;

            //bool case1 = distances[0] == 3 && distances[1] == 2 && distances[2] == 1 && distances[3] == 1 || distances[0] == 2 && distances[1] == 2 && distances[2] == 1 && distances[3] == 1;

            if (case3)
                //(generateIterator == 3 && distances[0] == 3 && distances[1] == 2 && distances[2] == 3)
            {
                //generate by 1 and 2, not 3
                //if (case5_) print("The case5!" + ThePlatform.transform.GetChild(0).gameObject.GetComponent<TextMeshPro>().text);
                //if (case3_) print("The case3!" + ThePlatform.transform.GetChild(0).gameObject.GetComponent<TextMeshPro>().text);
                
                if (DistanceGeneratingBalance >= 1 && DistanceGeneratingBalance <= 50)
                {
                    PlatformCountNumber = PlatformCountNumber + 1;
                    GenerateByDistance(1);
                    currentDistance = 1;

                }

                else if (DistanceGeneratingBalance > 50 && DistanceGeneratingBalance <= 100)
                {
                    PlatformCountNumber = PlatformCountNumber + 2;
                    GenerateByDistance(2);
                    currentDistance = 2;

                }
            }

            else if (case5)
            {
                PlatformCountNumber = PlatformCountNumber + 1;
                GenerateByDistance(1);
                currentDistance = 1;

            }

            /*else if (case1)
            {
                print("The case1!" + ThePlatform.transform.GetChild(0).gameObject.GetComponent<TextMeshPro>().text);
                PlatformCountNumber = PlatformCountNumber + 3;
                GenerateByDistance(3);
                currentDistance = 3;

            }*/

            else
            {
                if (DistanceGeneratingBalance >= 1 && DistanceGeneratingBalance <= 45)
                {
                    PlatformCountNumber = PlatformCountNumber + 1;
                    GenerateByDistance(1);
                    currentDistance = 1;

                }

                else if (DistanceGeneratingBalance > 45 && DistanceGeneratingBalance <= 65)
                {
                    PlatformCountNumber = PlatformCountNumber + 2;
                    GenerateByDistance(2);
                    currentDistance = 2;

                }
                else if (DistanceGeneratingBalance > 65 && DistanceGeneratingBalance <= 100)
                {
                    PlatformCountNumber = PlatformCountNumber + 3;
                    GenerateByDistance(3);
                    currentDistance = 3;

                }
            }



            if (AchievementBalance > 0 && AchievementBalance < 3 && int.Parse(jump1Limit.GetComponent<Text>().text) < 8) 
                ThePlatform.transform.GetChild(1).gameObject.SetActive(true);
            else ThePlatform.transform.GetChild(1).gameObject.SetActive(false);
            
            if (AchievementBalance > 3 && AchievementBalance < 7)
                ThePlatform.transform.GetChild(2).gameObject.SetActive(true);
            else ThePlatform.transform.GetChild(2).gameObject.SetActive(false);

            if (AchievementBalance > 7 && AchievementBalance < 10 && (int.Parse(ThePlatform.transform.GetChild(0).gameObject.GetComponent<TextMeshPro>().text) - lastMeteoritePlatform) > 10)
            {
                //print("this platform = " + ThePlatform.transform.GetChild(0).gameObject.GetComponent<TextMeshPro>().text + " last platform = " + lastMeteoritePlatform);
                
                lastMeteoritePlatform = int.Parse(ThePlatform.transform.GetChild(0).gameObject.GetComponent<TextMeshPro>().text);
                
                ThePlatform.transform.GetChild(3).gameObject.SetActive(true);
            }
            else ThePlatform.transform.GetChild(3).gameObject.SetActive(false);

            if (AchievementBalance > 10 && AchievementBalance < 15)
                ThePlatform.transform.GetChild(4).gameObject.SetActive(true);
            else ThePlatform.transform.GetChild(4).gameObject.SetActive(false);


            count.GetComponent<TextMeshPro>().text = "" + PlatformCountNumber;
            Instantiate(ThePlatform, transform.position, transform.rotation);

            for (int i = 1; i <= 3; i++)
                distances[i - 1] = distances[i];
            distances[3] = currentDistance;



            

            //print("distances = " + distances[0] + " " + distances[1] + " " + distances[2] + " " + distances[3]);
            //print("distances3 = " + distances[0] + " " + distances[1] + " " + distances[2]);
            //Debug.Log("currentDistance =" + currentDistance + " distances[generateIterator - 1] =" + distances[generateIterator - 1] + " generateIterator - 1 =" + (generateIterator - 1));
            //Debug.Log(distances[2] + " = distance3");
        }

    }
        
    
    
    
    
    
    private void GenerateByDistance(float distance)
    {
        transform.position = new Vector2(transform.position.x + distance * PlatformWidth + distance * DistanceBetween, transform.position.y);

    }

    // Update is called once per frame
    void Update()
    {
            SmartGeneratePlatfrom();
        


    }
}
