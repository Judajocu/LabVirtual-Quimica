using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoginProfessor : MonoBehaviour {

    public GameObject username;
    public GameObject password;
    public GameObject login;

    public Button buttonLogin;

    private string Username;
    private string Password;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Username = username.GetComponent<InputField>().text;
        Password = password.GetComponent<InputField>().text;               
    }

    public void ValidateLogin() {
        if(Username!=string.Empty && Password!=string.Empty)
        {
            print("Sup");
            SceneManager.LoadScene("Overview-Professor");
        }
    }

    public void ValidateBack()
    {
        SceneManager.LoadScene("Entryway");
    }
}
