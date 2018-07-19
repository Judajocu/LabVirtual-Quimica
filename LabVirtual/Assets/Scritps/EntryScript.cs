using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EntryScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Screen.orientation = ScreenOrientation.Portrait;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ValidationButtonProfessor() {
        SceneManager.LoadScene("Login-Professor");
    }

    public void ValidationButtonStudent() {
        SceneManager.LoadScene("Login-Student");
    }
}
