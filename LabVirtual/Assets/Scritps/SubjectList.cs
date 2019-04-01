using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.ServiceModel;

public class SubjectList : MonoBehaviour {

    public GameObject SubjectGradePrefab;

    Data_Overview_Student datagrid;

    int lastChangeCounter;

    private ServiceLabClient servicioWCF = new ServiceLabClient(new BasicHttpBinding(), new EndpointAddress("http://chemical.centralus.cloudapp.azure.com/servicelab.svc"));
    private UserSession Usuario;
    //private string[] simulaciones = new string[5] { "Nomenclatura", "Balanceo", "Estequiometria", "Tabla Periodica", "Conversion" }; //orden
    private string ID;
    private string[] notas;

    // Use this for initialization
    void Start () {
        

        datagrid = GameObject.FindObjectOfType<Data_Overview_Student>();

        lastChangeCounter = datagrid.GetChangeCounter() - 1;

        Usuario= GameObject.FindObjectOfType<UserSession>();
        ID = Usuario.darID();
        notas = servicioWCF.devolverNotasEst(ID);

        GameObject gameObject = (GameObject)Instantiate(SubjectGradePrefab, transform);
        gameObject.transform.SetParent(this.transform);

        if (notas[0].Equals("Null") || notas == null) { gameObject.transform.Find("TextNomenclaturaGrade").GetComponent<Text>().text = "0"; }
        else { gameObject.transform.Find("TextNomenclaturaGrade").GetComponent<Text>().text = notas[0]; }

        if (notas[1].Equals("Null") || notas == null) { gameObject.transform.Find("TextBalanceEGrade").GetComponent<Text>().text = "0"; }
        else { gameObject.transform.Find("TextBalanceEGrade").GetComponent<Text>().text = notas[1]; }

        if (notas[2].Equals("Null") || notas == null) { gameObject.transform.Find("TextEstequimetriaGrade").GetComponent<Text>().text = "0"; }
        else { gameObject.transform.Find("TextEstequimetriaGrade").GetComponent<Text>().text = notas[2]; }

        if (notas[3].Equals("Null") || notas == null) { gameObject.transform.Find("TextTablaPeriodicaGrade").GetComponent<Text>().text = "0"; }
        else { gameObject.transform.Find("TextTablaPeriodicaGrade").GetComponent<Text>().text = notas[3]; }

        if (notas[4].Equals("Null") || notas == null) { gameObject.transform.Find("TextConversionUGrade").GetComponent<Text>().text = "0"; }
        else { gameObject.transform.Find("TextConversionUGrade").GetComponent<Text>().text = notas[4]; }

    }
	
	// Update is called once per frame
	void Update () {
       

        /*

        if (datagrid.GetChangeCounter() == lastChangeCounter)
        {
            return;
        }
        else
        {
            lastChangeCounter = datagrid.GetChangeCounter();

            while (this.transform.childCount > 0)
            {
                Transform firstchild = this.transform.GetChild(0);
                firstchild.SetParent(null);
                Destroy(firstchild.gameObject);
            }

            string[] grades = datagrid.GetStudentGrades();

            GameObject gameObject = (GameObject)Instantiate(SubjectGradePrefab, transform);
            gameObject.transform.SetParent(this.transform);

            foreach (var subject in grades)
            {
                switch (subject)
                {
                    case "Nomenclatura":
                        gameObject.transform.Find("TextNomenclaturaGrade").GetComponent<Text>().text = datagrid.GetGrades(subject).ToString();
                        break;
                    case "Balance de Ecuaciones":
                        gameObject.transform.Find("TextBalanceEGrade").GetComponent<Text>().text = datagrid.GetGrades(subject).ToString();
                        break;
                    case "Tabla Periodica":
                        gameObject.transform.Find("TextTablaPeriodicaGrade").GetComponent<Text>().text = datagrid.GetGrades(subject).ToString();
                        break;
                    case "Estequiometria":
                        gameObject.transform.Find("TextEstequimetriaGrade").GetComponent<Text>().text = datagrid.GetGrades(subject).ToString();
                        break;
                    case "Conversion de Unidades":
                        gameObject.transform.Find("TextConversionUGrade").GetComponent<Text>().text = datagrid.GetGrades(subject).ToString();
                        break;
                    
                }
            }            
        }*/
    }

    void ShowGrade(string subject)
    {
        
    }
}
