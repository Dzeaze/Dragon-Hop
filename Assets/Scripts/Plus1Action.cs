using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Plus1Action : MonoBehaviour
{

    
    public Button b1;
    public Button b2;
    public Button b3;

    private int buttonValue1;
    private int buttonValue2;
    private int buttonValue3;

    //private bool b1pressed;
    //private bool b2pressed;
    //private bool b3pressed;
    
    
    // Start is called before the first frame update
    void Start()
    {
        buttonValue1 = int.Parse(b1.transform.GetChild(0).gameObject.GetComponent<Text>().text);
        buttonValue2 = int.Parse(b2.transform.GetChild(0).gameObject.GetComponent<Text>().text);
        buttonValue3 = int.Parse(b3.transform.GetChild(0).gameObject.GetComponent<Text>().text);

    }

    public void Plus1ActionOnClick()
    {
        StartCoroutine(Plus1());
    }

    IEnumerator Plus1()
    {
        //buttonValue1 ++;
        //buttonValue2 ++;
        //buttonValue3 ++;

        buttonValue1 = int.Parse(b1.transform.GetChild(0).gameObject.GetComponent<Text>().text);
        buttonValue2 = int.Parse(b2.transform.GetChild(0).gameObject.GetComponent<Text>().text);
        buttonValue3 = int.Parse(b3.transform.GetChild(0).gameObject.GetComponent<Text>().text);
        
        b1.transform.GetChild(0).gameObject.GetComponent<Text>().text = "" + (buttonValue1 + 1);
        b2.transform.GetChild(0).gameObject.GetComponent<Text>().text = "+" + (buttonValue2 + 1);
        b3.transform.GetChild(0).gameObject.GetComponent<Text>().text = "+" + (buttonValue3 + 1);

        //print("+1 1 done");

        yield return new WaitUntil(() => b1.GetComponent<PressedButton>().isPressed || b2.GetComponent<PressedButton>().isPressed || b3.GetComponent<PressedButton>().isPressed);
        yield return new WaitForSeconds(1);

        //print("+1 done");

        b1.transform.GetChild(0).gameObject.GetComponent<Text>().text = "" + buttonValue1;
        b2.transform.GetChild(0).gameObject.GetComponent<Text>().text = "+" + buttonValue2;
        b3.transform.GetChild(0).gameObject.GetComponent<Text>().text = "+" + buttonValue3;


    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
