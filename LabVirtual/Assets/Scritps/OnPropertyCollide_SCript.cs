﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.ServiceModel;

public class OnPropertyCollide_SCript : MonoBehaviour {

    #region Variables
    GameObject gameSymbol;
    
    public GameObject pesos;
    public GameObject electronegatividad;
    public GameObject pesosT;
    public GameObject electronegatividadT;

    public TextMesh ExpectedS;
    public TextMesh ExpectedM;
    public TextMesh ExpectedE;
    string QS;
    string QM;
    string QE;

    public GameObject Symbol1;
    public GameObject Symbol2;
    public GameObject Symbol3;
    public GameObject Symbol4;
    public GameObject Symbol5;

    public GameObject Mass1;
    public GameObject Mass2;
    public GameObject Mass3;
    public GameObject Mass4;
    public GameObject Mass5;

    public GameObject Electron1;
    public GameObject Electron2;
    public GameObject Electron3;
    public GameObject Electron4;
    public GameObject Electron5;

    List<string> results_expected = new List<string>();

    public string level;
    private string masaNombre = "Peso";
    private string ElectronNombre = "Electrones";
    private ServiceLabClient servicioWCF = new ServiceLabClient(new BasicHttpBinding(), new EndpointAddress("http://chemical.centralus.cloudapp.azure.com/servicelab.svc"));
    #endregion

    // Use this for initialization
    void Start()
    {

        GetExpectedResult();
    }

    void Awake()
    {
        string[] simulacionesNombre = new string[5] { "Soluciones", "Elemento", "Simbolos", "Masas", "Electrones" };
        string[] resultados = servicioWCF.BuscarDatosD("Tabla Periodica", level, simulacionesNombre);
        string[] ayudaMas = resultados[3].Split('@');
        string[] ayudaEle = resultados[4].Split('@');

        for (int i = 0; i < 5; i++)
        {
            GameObject.Find(masaNombre + (i + 1)).transform.GetChild(0).GetComponent<Text>().text = ayudaMas[i];
            GameObject.Find(ElectronNombre + (i + 1)).transform.GetChild(0).GetComponent<Text>().text = ayudaEle[i];
        }

        pesos.gameObject.SetActive(false);
        electronegatividad.gameObject.SetActive(false);
        pesosT.gameObject.SetActive(false);
        electronegatividadT.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("collisionando");
        if (collision.gameObject.tag == "Symbol")
        {
            QS = collision.transform.gameObject.GetComponentInChildren<Text>().text;
            pesos.gameObject.SetActive(true);
            pesosT.gameObject.SetActive(true);
            Destroy(GameObject.FindGameObjectWithTag("Placeholder"));
            Destroy(GameObject.FindGameObjectWithTag("Signo"));
            switch (collision.gameObject.name)
            {
                case "Signo1":
                    gameSymbol = Instantiate(Symbol1, new Vector3(-5.5f, -21f, -7887.205f), Quaternion.identity);
                    gameSymbol.transform.SetParent(GameObject.FindGameObjectWithTag("Element").transform, false);
                    break;
                case "Signo2":
                    gameSymbol = Instantiate(Symbol2, new Vector3(-5.5f, -21f, -7887.205f), Quaternion.identity);
                    gameSymbol.transform.SetParent(GameObject.FindGameObjectWithTag("Element").transform, false);
                    break;
                case "Signo3":
                    gameSymbol = Instantiate(Symbol3, new Vector3(-5.5f, -21f, -7887.205f), Quaternion.identity);
                    gameSymbol.transform.SetParent(GameObject.FindGameObjectWithTag("Element").transform, false);
                    break;
                case "Signo4":
                    gameSymbol = Instantiate(Symbol4, new Vector3(-5.5f, -21f, -7887.205f), Quaternion.identity);
                    gameSymbol.transform.SetParent(GameObject.FindGameObjectWithTag("Element").transform, false);
                    break;
                case "Signo5":
                    gameSymbol = Instantiate(Symbol5, new Vector3(0f, -21f, -7887.205f), Quaternion.identity);
                    gameSymbol.transform.SetParent(GameObject.FindGameObjectWithTag("Element").transform, false);
                    break;
            }           
        }

        if (collision.gameObject.tag == "Weight")
        {
            QM = collision.transform.gameObject.GetComponentInChildren<Text>().text;
            electronegatividad.gameObject.SetActive(true);
            electronegatividadT.gameObject.SetActive(true);
            Destroy(GameObject.FindGameObjectWithTag("Mass"));
            switch (collision.gameObject.name)
            {
                case "Peso1":
                    gameSymbol = Instantiate(Mass1, new Vector3(-3f, -21f, -7885.205f), Quaternion.identity);
                    gameSymbol.transform.SetParent(GameObject.FindGameObjectWithTag("Element").transform, false);
                    break;
                case "Peso2":
                    gameSymbol = Instantiate(Mass2, new Vector3(-3f, -21f, -7885.205f), Quaternion.identity);
                    gameSymbol.transform.SetParent(GameObject.FindGameObjectWithTag("Element").transform, false);
                    break;
                case "Peso3":
                    gameSymbol = Instantiate(Mass3, new Vector3(-3f, -21f, -7885.205f), Quaternion.identity);
                    gameSymbol.transform.SetParent(GameObject.FindGameObjectWithTag("Element").transform, false);
                    break;
                case "Peso4":
                    gameSymbol = Instantiate(Mass5, new Vector3(-3f, -21f, -7885.205f), Quaternion.identity);
                    gameSymbol.transform.SetParent(GameObject.FindGameObjectWithTag("Element").transform, false);
                    break;
                case "Peso5":
                    gameSymbol = Instantiate(Mass4, new Vector3(-3f, -21f, -7885.205f), Quaternion.identity);
                    gameSymbol.transform.SetParent(GameObject.FindGameObjectWithTag("Element").transform, false);
                    break;
            }
        }

        if (collision.gameObject.tag == "Electrons")
        {
            QE = collision.transform.gameObject.GetComponentInChildren<Text>().text;
            Destroy(GameObject.FindGameObjectWithTag("Electrones"));
            switch (collision.gameObject.name)
            {
                case "Electrones1":
                    gameSymbol = Instantiate(Electron5, new Vector3(-6f, -19f, -7887.205f), Quaternion.identity);
                    gameSymbol.transform.SetParent(GameObject.FindGameObjectWithTag("Element").transform, false);
                    break;
                case "Electrones2":
                    gameSymbol = Instantiate(Electron1, new Vector3(-6f, -19f, -7887.205f), Quaternion.identity);
                    gameSymbol.transform.SetParent(GameObject.FindGameObjectWithTag("Element").transform, false);
                    break;
                case "Electrones3":
                    gameSymbol = Instantiate(Electron4, new Vector3(-6f, -19f, -7887.205f), Quaternion.identity);
                    gameSymbol.transform.SetParent(GameObject.FindGameObjectWithTag("Element").transform, false);
                    break;
                case "Electrones5":
                    gameSymbol = Instantiate(Electron3, new Vector3(-6f, -19f, -7887.205f), Quaternion.identity);
                    gameSymbol.transform.SetParent(GameObject.FindGameObjectWithTag("Element").transform, false);
                    break;
                case "Electrones4":
                    gameSymbol = Instantiate(Electron2, new Vector3(-6f, -19f, -7887.205f), Quaternion.identity);
                    gameSymbol.transform.SetParent(GameObject.FindGameObjectWithTag("Element").transform, false);
                    break;
            }
        }
    }

    public void GetExpectedResult()
    {
        results_expected.Add(ExpectedS.text);
        results_expected.Add(ExpectedM.text);
        results_expected.Add(ExpectedE.text);
        
    }

    public void enviar()
    {
        bool respuesta;
        GetExpectedResult();
        Debug.Log(QS + " " + QM + " " + QE);
        if (QS == results_expected[0] && QM == results_expected[1] && QE == results_expected[2])
            respuesta = true;
        else
            respuesta = false;


        GameObject.FindGameObjectWithTag("Player").GetComponent<Simulation_Table_Script>().SendMessage("respuesta", respuesta);


    }
}
