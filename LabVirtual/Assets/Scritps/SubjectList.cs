using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubjectList : MonoBehaviour {

    public GameObject SubjectGradePrefab;

    Data_Overview_Student datagrid;

    int lastChangeCounter;

    // Use this for initialization
    void Start () {

        datagrid = GameObject.FindObjectOfType<Data_Overview_Student>();

        lastChangeCounter = datagrid.GetChangeCounter() - 1;

    }
	
	// Update is called once per frame
	void Update () {
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

            ShowGrade("Nomenclatura");
            ShowGrade("Balance de Ecuaciones");
            ShowGrade("Tabla Periodica");
            ShowGrade("Conversion de Unidades");
            ShowGrade("Estequiometria");

        }
    }

    void ShowGrade(string subject)
    {
        int grade = datagrid.GetGrades(subject);

        GameObject gameObject = (GameObject)Instantiate(SubjectGradePrefab, transform);
        gameObject.transform.SetParent(this.transform);

        switch(subject)
        {
            case "Nomenclatura":
                gameObject.transform.Find("TextNomenclaturaGrade").GetComponent<Text>().text = grade.ToString();
                break;
            case "Balance de Ecuaciones":
                gameObject.transform.Find("TextBalanceEGrade").GetComponent<Text>().text = grade.ToString();
                break;
            case "Tabla Periodica":
                gameObject.transform.Find("TextTablaPeriodicaGrade").GetComponent<Text>().text = grade.ToString();
                break;
            case "Conversion de Unidades":
                gameObject.transform.Find("TextConversionUGrade").GetComponent<Text>().text = grade.ToString();
                break;
            case "Estequiometria":
                gameObject.transform.Find("TextEstequimetriaGrade").GetComponent<Text>().text = grade.ToString();
                break;
        }        
    }
}
