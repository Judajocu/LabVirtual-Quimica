using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class watchGlassBehavior : MonoBehaviour {

    public TextMesh palabra =null;
    private string word = null;
    private int wordindex = 0;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void resultado(GameObject esto)
    {
        //esto.gameObject.transform.GetChild(0).gameObject.GetComponent<UnityEngine.UI.Text>().text = "D";
        wordindex++;
        word = word + esto.gameObject.transform.GetChild(0).gameObject.GetComponent<UnityEngine.UI.Text>().text;
        palabra.text = word;
    }
}
