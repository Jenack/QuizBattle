using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;

public class Flags : MonoBehaviour {

    public GameObject[] flagButton; //Makes a box in Unity Editor so we can drag and drop the elemen we need
    public GameObject showAnwser;
    public string[] flagNameArray; //Visual array to check the county names are loaded correctly
    public Sprite[] allFlags; //Visual array to check the flags are loaded correctly
    public Text QuestionText; //Makes a box in Unity Editor so we can drag and drop the element we need
    public GameObject True;
    public GameObject False;

    private List<int> flagCheck = new List<int>(); //Creates a list for the purpose of tracking our randomly selected flags, to make sure that a flag can only be selected once
    private int CorrectFlag;

    // Use this for initialization
    void Start()
    {
        LoadFlags();
        LoadCountries();
        PlaceFlags();
    }

    //Function to load a text file which contains the countries of the flags we have
    void LoadCountries() {
        TextAsset textFile = Resources.Load("Countries") as TextAsset;
        //Debug.Log(textFile); //Used to debug if file loaded or not 
        flagNameArray = textFile.text.Split('\n');
    }
    
    void LoadFlags() {
        //Load the Sprites folder from the Resources folder
        Sprite[] imports = Resources.LoadAll<Sprite>("Sprites");
        //Array to store the flag sprites
        allFlags = new Sprite[imports.Length];

        for (var i = 0 ; i < allFlags.Length; i++) {
            allFlags[i] = imports[i];
        }
    }
    
    void PlaceFlags() {

        True.SetActive(false);
        False.SetActive(false);

        for (int i = 0; i < flagButton.Length; i++)
        {
            //Flag indexes, tells us which flags we have in our questions
            int randomFlagIndex = Random.Range(0, allFlags.Length);
            while(flagCheck.Contains(randomFlagIndex)){
                randomFlagIndex = Random.Range(0, allFlags.Length);
            }
            flagCheck.Add(randomFlagIndex);
            //used to debug that the corresponding flag contains the correct country name 
            //Debug.Log("Flag Number " + i + " is named " + flagButton[i].name);
            flagButton[i].GetComponent<Image>().sprite = allFlags[randomFlagIndex];
            flagButton[i].GetComponent<MaterialUI.SpriteSwapper>().sprite1x = allFlags[randomFlagIndex];
            flagButton[i].GetComponent<MaterialUI.SpriteSwapper>().sprite2x = allFlags[randomFlagIndex];
            flagButton[i].GetComponent<MaterialUI.SpriteSwapper>().sprite4x = allFlags[randomFlagIndex];
        }

        CorrectFlag = Random.Range(0, 4);
        //Random flag index
        //QuestionText.text = "Which flag is "+flagNameArray[flagCheck[CorrectFlag]]+"s?";
        QuestionText.text = flagNameArray[flagCheck[CorrectFlag]];
    }

    IEnumerator FlagTimer(){
        //print(Time.time);
        yield return new WaitForSeconds(5);
        //print(Time.time);
    } 

    public void ClickFlag1() {
        if (CorrectFlag == 0)
        {
            Debug.Log("Correct Flag " + flagNameArray[flagCheck[CorrectFlag]]);
            True.SetActive(true);
            StartCoroutine(FlagTimer());
            Debug.Log("I was enabled " + True.activeInHierarchy);
            //True.SetActive(false);
            flagCheck.Clear();
            PlaceFlags();
            StopCoroutine(FlagTimer());
        }
        else
        {
            Debug.Log("Wrong Flag! Correct flag was " + flagNameArray[flagCheck[CorrectFlag]]);
            False.SetActive(true);
            Debug.Log("I was enabled " + False.activeInHierarchy);
            StartCoroutine(FlagTimer());
            //False.SetActive(false);
            flagCheck.Clear();
            PlaceFlags();
            StopCoroutine(FlagTimer());
        }
    }

    public void ClickFlag2() {
        if (CorrectFlag == 1)
        {
            Debug.Log("Correct Flag " + flagNameArray[flagCheck[CorrectFlag]]);
            True.SetActive(true);
            StartCoroutine(FlagTimer());
            Debug.Log("I was enabled " + True.activeInHierarchy);
            //True.SetActive(false);
            flagCheck.Clear();
            PlaceFlags();
            StopCoroutine(FlagTimer());
        }
        else
        {
            Debug.Log("Wrong Flag! Correct flag was " + flagNameArray[flagCheck[CorrectFlag]]);
            False.SetActive(true);
            Debug.Log("I was enabled " + False.activeInHierarchy);
            StartCoroutine(FlagTimer());
            //False.SetActive(false);
            flagCheck.Clear();
            PlaceFlags();
            StopCoroutine(FlagTimer());
        }
    }

    public void ClickFlag3() {
        if (CorrectFlag == 2)
        {
            Debug.Log("Correct Flag " + flagNameArray[flagCheck[CorrectFlag]]);
            True.SetActive(true);
            StartCoroutine(FlagTimer());
            Debug.Log("I was enabled " + True.activeInHierarchy);
            //True.SetActive(false);
            flagCheck.Clear();
            PlaceFlags();
            StopCoroutine(FlagTimer());
        }
        else
        {
            Debug.Log("Wrong Flag! Correct flag was " + flagNameArray[flagCheck[CorrectFlag]]);
            False.SetActive(true);
            Debug.Log("I was enabled " + False.activeInHierarchy);
            StartCoroutine(FlagTimer());
            //False.SetActive(false);
            flagCheck.Clear();
            PlaceFlags();
            StopCoroutine(FlagTimer());
        }
    }

    public void ClickFlag4() {
        if (CorrectFlag == 3)
        {
            Debug.Log("Correct Flag " + flagNameArray[flagCheck[CorrectFlag]]);
            True.SetActive(true);
            StartCoroutine(FlagTimer());
            Debug.Log("I was enabled " + True.activeInHierarchy);
            //True.SetActive(false);
            flagCheck.Clear();
            PlaceFlags();
            StopCoroutine(FlagTimer());
        }
        else
        {
            Debug.Log("Wrong Flag! Correct flag was " + flagNameArray[flagCheck[CorrectFlag]]);
            False.SetActive(true);
            Debug.Log("I was enabled " + False.activeInHierarchy);
            StartCoroutine(FlagTimer());
            //False.SetActive(false);
            flagCheck.Clear();
            PlaceFlags();
            StopCoroutine(FlagTimer());
        }
    }

    public void CheatButton() {
        /*Outline the correct flag button
        flagButton[flagNameArray[flagCheck[CorrectFlag]]].GetComponent<Image>().sprite = Outline THE IMAGE*/
        Debug.Log("Slider value is " + MaterialUI.SliderConfig().slider.value);

    }

    public static void SaveToFile() {
        StreamWriter sw = new StreamWriter(Application.persistentDataPath + "anwsers.txt");

        sw.WriteLine("Generated table of 1 to 10");
        sw.WriteLine("");

        for (int i = 1; i <= 10; i++)
        {
            for (int j = 1; j <= 10; j++)
            {
                sw.WriteLine("{0}x{1}= {2}", i, j, (i * j));
            }

            sw.WriteLine("====================================");
        }

        sw.WriteLine("Table successfully written to file!");

        sw.Close();
    }
}