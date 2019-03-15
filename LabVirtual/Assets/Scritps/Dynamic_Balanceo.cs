using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Dynamic_Balanceo : MonoBehaviour {

    public Button buttonSave;

    public GameObject ButtonAceptar;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ValidateChange()
    {
        SceneManager.LoadScene("Dynamic_Simulations");
    }

}
