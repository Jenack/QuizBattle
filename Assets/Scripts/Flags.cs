using UnityEngine;
using System.Collections;
using System.Linq; //Needed??

public class Flags : MonoBehaviour {
    

    public GameObject[] flagAnwsers;
    public string[] flagNameArray;
    public Sprite[] allFlags;
   
	// Use this for initialization
	void Start () {
	    Object[] imports = (Sprite[]); Resources.LoadAll("Assets/Sprites/*.png");

        allFlags = new Sprite[allFlags.Length];
        
        for (var i = 0 ; i < allFlags.Length; i++) {
            allFlags[i] = imports[i];
        }
        //sorts them wierdly :p 3,4,1,2?? :P
        //flagAnwsers = GameObject.FindGameObjectsWithTag("Flag");

        for (int i = 0; i < flagAnwsers.Length; i++)
        {
            Debug.Log("Flag Number " + i + " is named " + flagAnwsers[i].name);
        }
	}
	
	// Update is called once per frame
	void Update () {

	}
}
