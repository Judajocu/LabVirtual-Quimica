using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoginStudent : MonoBehaviour {

    public GameObject id;
    public GameObject password;
    public GameObject login;

    public Button buttonLogin;

    private string ID;
    private string Password;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        ID = id.GetComponent<InputField>().text;
        Password = password.GetComponent<InputField>().text;
              
    }

    public void ValidateLogin() {
        if(ID!=string.Empty && Password != string.Empty)
        {
            print("Sup");
            SceneManager.LoadScene("Overview-Student");
        }
    }
    public void ValidateBack()
    {
        SceneManager.LoadScene("Entryway");
    }
}
