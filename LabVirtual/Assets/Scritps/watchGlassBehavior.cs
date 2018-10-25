using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class watchGlassBehavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void resultado(GameObject esto)
    {
        esto.gameObject.transform.GetChild(0).gameObject.GetComponent<UnityEngine.UI.Text>().text = "D";
    }
}
