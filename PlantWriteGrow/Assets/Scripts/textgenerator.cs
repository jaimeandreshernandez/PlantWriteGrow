using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;


public class textgenerator : MonoBehaviour {

    System.Random rand = new System.Random();
    public Text textManager;
    public Camera mainCam;
    public int wordLength;
    int currentChar;
    int smallCaseLow = 97;
    int smallCaseHigh = 122;
    int minLength = 1;
    int maxLength = 10;
    string word = "";
    public float x = -150f;
    public float y = 0f;
    public float z = 0f;
    int tmr1000 = 0;




    // Use this for initialization
    void Start () {
        textManager.text = getWord();
    }
	
	// Update is called once per frame
	void Update () {

        x += 0.5f;
        

        

        
            int tick = Environment.TickCount;

            if (tick > tmr1000)
            {
                // Do your logic here.
                textManager.rectTransform.position.Set(x, 0, 0);
                textManager.text = getWord();
                tmr1000 = tick + 1000;
            }

        
    }

    //return a word
    public string getWord()
    {
        word = "";
        wordLength = rand.Next(minLength, maxLength);
        for(int x=minLength; x<=wordLength; x++)
        {
            word += (char)rand.Next(smallCaseLow, smallCaseHigh);
        }

        //textManager.text = word;

        wait(100f);
        return word;
    }

    public IEnumerator wait(float f)
    {
        yield return new WaitForSeconds(f);
    }
}
