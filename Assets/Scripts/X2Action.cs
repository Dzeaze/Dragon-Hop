using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class X2Action : MonoBehaviour
{


    //bool getAchievement;
    public bool x2Action;
    private float coroutineIterator;
    public Button b1;
    public Button b2;
    public Button b3;

    public Text jumplimit;

    private int buttonValue1;
    private int buttonValue2;
    private int buttonValue3;

    //GameObject ach;


    // Start is called before the first frame update


    void Start()
    {
        buttonValue1 = int.Parse(b1.transform.GetChild(0).gameObject.GetComponent<Text>().text);
        buttonValue2 = int.Parse(b2.transform.GetChild(0).gameObject.GetComponent<Text>().text);
        buttonValue3 = int.Parse(b3.transform.GetChild(0).gameObject.GetComponent<Text>().text);
        x2Action = false;
        coroutineIterator = 1;

        jumplimit = jumplimit.GetComponent<Text>();


    }



    IEnumerator X2Buttons()
    {
        //print("x2 start");
        coroutineIterator++;
        buttonValue1 = int.Parse(b1.transform.GetChild(0).gameObject.GetComponent<Text>().text);
        buttonValue2 = int.Parse(b2.transform.GetChild(0).gameObject.GetComponent<Text>().text);
        buttonValue3 = int.Parse(b3.transform.GetChild(0).gameObject.GetComponent<Text>().text);

        b1.transform.GetChild(0).gameObject.GetComponent<Text>().text = "" + (buttonValue1 * 2);
        b2.transform.GetChild(0).gameObject.GetComponent<Text>().text = "+" + (buttonValue2 * 2);
        b3.transform.GetChild(0).gameObject.GetComponent<Text>().text = "+" + (buttonValue3 * 2);

        //print("x2 1 done b1" + b1.transform.GetChild(0).gameObject.GetComponent<Text>().text);

        yield return new WaitUntil(() => (b1.GetComponent<PressedButton>().isPressed && int.Parse(jumplimit.text) != 0) || b2.GetComponent<PressedButton>().isPressed || b3.GetComponent<PressedButton>().isPressed);
        yield return new WaitForSeconds(1);

        //print("x2 done");
        coroutineIterator = 1;
        b1.transform.GetChild(0).gameObject.GetComponent<Text>().text = "" + buttonValue1;
        b2.transform.GetChild(0).gameObject.GetComponent<Text>().text = "+" + buttonValue2;
        b3.transform.GetChild(0).gameObject.GetComponent<Text>().text = "+" + buttonValue3;

        x2Action = false;



    }





    // Update is called once per frame
    void Update()
    {
        if (x2Action && coroutineIterator == 1)
        {

            StartCoroutine(X2Buttons());
        }
    }
}
