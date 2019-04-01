using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.ServiceModel;

public class LoginProfessor : MonoBehaviour {

    public GameObject username;
    public GameObject password;
    public GameObject login;

    public Button buttonLogin;

    private string Username;
    private string Password;

    private bool logueo = false;
    public GameObject letrero;

    // Use this for initialization
    void Start () {
        letrero.gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
                       
    }

    public void ValidateLogin() {
        Username = username.GetComponent<InputField>().text;
        Password = password.GetComponent<InputField>().text;
        if (Username!=string.Empty && Password!=string.Empty)
        {
            //prueva guardado de datos en la base de datos
            string problem = "no se hizo la coneccion";
            GameObject.FindGameObjectWithTag("seccion").GetComponent<UserSession>().SendMessage("cambio", Username);
            try
            {
                ServiceLabClient servicioWCF = new ServiceLabClient(new BasicHttpBinding(), new EndpointAddress("http://chemical.centralus.cloudapp.azure.com/servicelab.svc"));
                
                logueo = servicioWCF.verificarProfesor(Username, Password);
                
            }
            catch (System.Exception ex)
            {
                print(problem);
                print(ex.ToString());
            }

            if (logueo)
            {
                print("Sup");
                SceneManager.LoadScene("Overview-Professor");
            }
            else
            {
                letrero.gameObject.SetActive(true);
            }
        }
    }

    public void ValidateBack()
    {
        SceneManager.LoadScene("Entryway");
    }
}
