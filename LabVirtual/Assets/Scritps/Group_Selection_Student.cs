using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.ServiceModel;
using System;

public class Group_Selection_Student : MonoBehaviour {

    #region Variables
    public Dropdown dropdown;
    public Button Exit;
    public Button Submit;
    public Text nombre;

    private UserSession Usuario;
    private ServiceLabClient servicioWCF = new ServiceLabClient(new BasicHttpBinding(), new EndpointAddress("http://chemilabservice.azurewebsites.net/ServiceLab.svc"));
    private string ID;
    private string[] grupos;
    private string[] nombres;
    private int[] iDs;
    List<string> esto = new List<string>();
    private string defecto = "Opcion";

    private string ayu;
    private int actual;
    #endregion

    // Use this for initialization
    void Start () {

        Usuario = GameObject.FindObjectOfType<UserSession>();
        ID = Usuario.darID();
        grupos = servicioWCF.DarListaEstudentGrupo(ID);
        nombres = new string[grupos.Length];
        iDs = new int[grupos.Length];

        dropdown.ClearOptions();
        for (int j = 0; j < grupos.Length; j++)
        {
            string[] ayuda = grupos[j].Split('@');
            nombres[j] = ayuda[0];
            iDs[j] = Int32.Parse(ayuda[1]);
            int n = j + 1;
            esto.Add(defecto + " " + n.ToString());
            //lala += ayuda[0]+": "+ayuda[1] + Environment.NewLine;
        }
        //GameObject.Find("TextC").GetComponent<Text>().text = lala;

        dropdown.AddOptions(esto);

    }
	
	// Update is called once per frame
	void Update () {

        GetNivel();
        int b = 0;
        foreach (string a in esto)
        {
            if (ayu.Equals(a))
            {
                nombre.text = nombres[b];
                actual = iDs[b];

            }
            b++;
        }

    }

    public void GetNivel()
    {
        ayu = dropdown.options[dropdown.value].text;
    }

    public void ValidateSubmit()
    {
        GameObject.FindGameObjectWithTag("seccion").GetComponent<UserSession>().SendMessage("groupSelected", actual);
        SceneManager.LoadScene("Overview-Student");
    }

    public void ValidateExit()
    {
        SceneManager.LoadScene("Login-Student");
    }
}
