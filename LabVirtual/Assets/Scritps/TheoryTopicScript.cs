using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.ServiceModel;
using System;

public class TheoryTopicScript : MonoBehaviour {

    #region Variables
    public Button buttonMenu;
    public Button buttonPVA;
    public Button buttonSimulacion;

    public GameObject menu;
    public GameObject pva;
    public GameObject simulacion;

    private ServiceLabClient servicioWCF = new ServiceLabClient(new BasicHttpBinding(), new EndpointAddress("http://localhost:21826/ServiceLab.svc"));
    public Dropdown opciones;
    public Button ButtonLink;
    public Text nombre;
    private string[] nombres;
    private string[] links;
    List<string> esto = new List<string>();
    private string actual, ayu;
    private string defecto = "Opcion";
    #endregion

    // Use this for initialization
    void Start () {
        string[] resultados = servicioWCF.LinkDocumentos();
        nombres = new string[resultados.Length];
        links = new string[resultados.Length];
        //string lala = "";
        opciones.ClearOptions();
        for (int j = 0; j < resultados.Length; j++)
        {
            string[] ayuda = resultados[j].Split('|');
            nombres[j] = ayuda[0];
            links[j] = ayuda[1];
            int n = j + 1;
            esto.Add(defecto + " " + n.ToString());
            //lala += ayuda[0]+": "+ayuda[1] + Environment.NewLine;
        }
        //GameObject.Find("TextC").GetComponent<Text>().text = lala;

        opciones.AddOptions(esto);

    }
	
	// Update is called once per frame
	void Update () {
        GetNivel();
        int b = 0;
        foreach(string a in esto)
        {
            if (ayu.Equals(a))
            {
                nombre.text = nombres[b];
                actual = links[b];

            }
            b++;
        }
		
	}

    public void GetNivel()
    {
        ayu = opciones.options[opciones.value].text;
    }

    public void ValidateMenu()
    {
        SceneManager.LoadScene("Options_Student");
    }

    public void ValidatePVA()
    {
        
    }

    public void ValidateSimulacion()
    {
        SceneManager.LoadScene("Simulation_Selection_Options");
    }

    public void go()
    {
        Application.OpenURL(actual);
    }




}
