using UnityEngine;
using System.Collections;
using System.Linq; //Needed??

public class Flags : MonoBehaviour {


    public GameObject[] flagAnwsers;
    public string[] flagArray;
    
	// Use this for initialization
	void Start () {
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
