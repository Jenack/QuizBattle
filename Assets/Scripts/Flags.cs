using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;

public class Flags : MonoBehaviour {

    public GameObject[] flagButton; //Makes a box in Unity Editor so we can drag and drop the elemen we need
    public string[] flagNameArray; //Visual array to check the county names are loaded correctly
    public Sprite[] allFlags; //Visual array to check the flags are loaded correctly
    public Text QuestionText; //Makes a box in Unity Editor so we can drag and drop the element we need
    
    public GameObject True;
    public GameObject False;
    public GameObject BlockInput;
    
    public Text ScoreText; //The gameobject for the 
    private int flagScore;

    public GameObject showAnwser;
    private int showAnwserClicked;

    public Text QuestionCounter;
    private int totalAnwseredQuestion = 1;

    private List<int> flagCheck = new List<int>(); //Creates a list for the purpose of tracking our randomly selected flags, to make sure that a flag can only be selected once
    private int CorrectFlag;

    public GameObject ConationCanvas;
    public GameObject ConationSubmit;
    public Slider ConationSlider;
    public GameObject ExitGame;
    List<int> sliderValue = new List<int>();
    private static string DataOutput = "Output.txt";

    // Use this for initialization
    void Start() {
        LoadFlags();
        LoadCountries();
        PlaceFlags();
    }

    void Score() {
        flagScore += 1;
        ScoreText.text = "Score: "+flagScore.ToString();
    }

    void Question() {
        totalAnwseredQuestion += 1;
        QuestionCounter.text = "Question "+totalAnwseredQuestion.ToString();
    }

    void Questionnaire() {
        if (totalAnwseredQuestion%10 == 0)
            ConationCanvas.SetActive(true);
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

        for (var i = 0; i < allFlags.Length; i++)
        {
            allFlags[i] = imports[i];
        }
    }

    void PlaceFlags() {

        BlockInput.SetActive(false);
        True.SetActive(false);
        False.SetActive(false);

        for (int i = 0; i < flagButton.Length; i++) {
            //Flag indexes, tells us which flags we have in our questions
            int randomFlagIndex = Random.Range(0, allFlags.Length);
            while (flagCheck.Contains(randomFlagIndex))
            {
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

    IEnumerator FlagTimer(bool wasItCorrect) {
        BlockInput.SetActive(true);
        True.SetActive(wasItCorrect);
        False.SetActive(!wasItCorrect);
        yield return new WaitForSeconds(2);

        if (wasItCorrect) {
            Score();
            Question();
        }
        else
        {
            Question();
        }
        Questionnaire();
        flagCheck.Clear();
        PlaceFlags();
        StopCoroutine(FlagTimer(wasItCorrect));
    }

    public void ClickFlag1() {
        if (CorrectFlag == 0)
        {
            Debug.Log("Correct Flag " + flagNameArray[flagCheck[CorrectFlag]]);
            StartCoroutine(FlagTimer(true));
        }
        else
        {
            Debug.Log("Wrong Flag! Correct flag was " + flagNameArray[flagCheck[CorrectFlag]]);
            StartCoroutine(FlagTimer(false));
        }
    }

    public void ClickFlag2() {
        if (CorrectFlag == 1)
        {
            Debug.Log("Correct Flag " + flagNameArray[flagCheck[CorrectFlag]]);
            StartCoroutine(FlagTimer(true));
        }
        else
        {
            Debug.Log("Wrong Flag! Correct flag was " + flagNameArray[flagCheck[CorrectFlag]]);
            StartCoroutine(FlagTimer(false));
        }
    }

    public void ClickFlag3() {
        if (CorrectFlag == 2)
        {
            Debug.Log("Correct Flag " + flagNameArray[flagCheck[CorrectFlag]]);
            StartCoroutine(FlagTimer(true));
        }
        else
        {
            Debug.Log("Wrong Flag! Correct flag was " + flagNameArray[flagCheck[CorrectFlag]]);
            StartCoroutine(FlagTimer(false));
        }
    }

    public void ClickFlag4() {
        if (CorrectFlag == 3)
        {
            Debug.Log("Correct Flag " + flagNameArray[flagCheck[CorrectFlag]]);
            StartCoroutine(FlagTimer(true));
        }
        else
        {
            Debug.Log("Wrong Flag! Correct flag was " + flagNameArray[flagCheck[CorrectFlag]]);
            StartCoroutine(FlagTimer(false));
        }
    }

    IEnumerator cheatTimer() {
        for (int i = 0; i < 4; i++) {
            if (i != CorrectFlag)
            {
                flagButton[i].GetComponent<Image>().color = new Color(1, 1, 1, 0.3f);
            }
        }
        yield return new WaitForSeconds(1.5f);


        for (int i = 0; i < 4; i++) {
            if (i != CorrectFlag)
            {
                flagButton[i].GetComponent<Image>().color = new Color(1, 1, 1, 1);
            }
        }
    }


    public void CheatButton() {
        StartCoroutine(cheatTimer());
        showAnwserClicked += 1;
        Debug.Log(showAnwserClicked);
    }

    public void submitButton() {
        ConationCanvas.SetActive(false);
        sliderValue.Add((int)ConationSlider.value);
        //Debug.Log(ConationSlider.value);
    }

    public void quitButton() {
        sliderValue.Add((int)ConationSlider.value);
        SaveToFile();
        Application.Quit();
    }
    
    public void SaveToFile() {

        StreamWriter sw = new StreamWriter(Application.dataPath + DataOutput);

        sw.WriteLine("Cheat button was clicked: " + showAnwserClicked);
        
        foreach (float f in sliderValue) {
            sw.WriteLine("The conation value was: " + f);
        }

        sw.WriteLine("Amount of question asked was: " + totalAnwseredQuestion);
        sw.WriteLine("Score was: " + flagScore);
        sw.Flush();
        sw.Close();
    }
}